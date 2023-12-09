using ArticleCancer.Application.DTOs.ToDos;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class ToDoService : IToDoService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;

        public ToDoService(IUnıtOfWork unıtOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }
        public async Task<string> ChangeStatusCompletedAsync(Guid toDoId)
        {
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var order = await _unıtOfWork.GetRepository<ToDo>().GetAsync(x => x.ToDoID == toDoId && !x.IsDeleted && x.UserID == userID, x => x.User);
            order.ModifiedDate = DateTime.Now;
            order.ModifiedBy = userEmail;
            order.Status = "Tamamlandı";
            await _unıtOfWork.GetRepository<ToDo>().UpdateAsync(order);
            await _unıtOfWork.SaveAsync();

            return order.Name;
        }

        public async Task<string> ChangeStatusNonCompletedAsync(Guid toDoId)
        {
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var order = await _unıtOfWork.GetRepository<ToDo>().GetAsync(x => x.ToDoID == toDoId && !x.IsDeleted && x.UserID == userID, x => x.User);
            order.ModifiedDate = DateTime.Now;
            order.ModifiedBy = userEmail;
            order.Status = "Tamamlanmadı";
            await _unıtOfWork.GetRepository<ToDo>().UpdateAsync(order);
            await _unıtOfWork.SaveAsync();

            return order.Name;
        }

        public async Task CreateToDoAsync(ToDoAddDto toDoAddDto)
        {
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var map = _mapper.Map<ToDo>(toDoAddDto);
            map.CreatedBy = userEmail;
            map.UserID = userID;
            await _unıtOfWork.GetRepository<ToDo>().AddAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public async Task<List<ToDoDto>> GetAllCompletedToDosNonDeletedByUserAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => !x.IsDeleted && x.UserID == userID && x.Status == "Tamamlandı");
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map;
        }

        public async Task<List<ToDoDto>> GetAllNonCompletedToDosNonDeletedByUserAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => !x.IsDeleted && x.UserID == userID && x.Status == "Tamamlanmadı");
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map;
        }

        public async Task<List<ToDoDto>> GetAllToDosDeleted()
        {
            var userID = _user.GetLoggedInUserId();
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => x.IsDeleted);
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map;
        }

        public async Task<List<ToDoDto>> GetAllToDosDeletedByUserAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => x.IsDeleted && x.UserID == userID);
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map;
        }

        public async Task<List<ToDoDto>> GetAllToDosNonDeletedAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map;
        }

        public async Task<List<ToDoDto>> GetAllToDosNonDeletedByUserAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => !x.IsDeleted && x.UserID == userID);
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map;
        }

        public async Task<List<ToDoDto>> GetAllToDosNonDeletedTake24()
        {
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<ToDoDto>>(categories);
            return map.Take(24).ToList();
        }

        public async Task<ToDoDto> GetToDoByID(Guid toDoId)
        {
            var categories = await _unıtOfWork.GetRepository<ToDo>().GetAsync(x => x.ToDoID == toDoId);
            var map = _mapper.Map<ToDoDto>(categories);
            return map;
        }

        public async Task<string> HardDeleteToDoAsync(Guid todoId)
        {
            var category = await _unıtOfWork.GetRepository<ToDo>().GetByGuidAsync(todoId);
            await _unıtOfWork.GetRepository<ToDo>().DeleteAsync(category);
            await _unıtOfWork.SaveAsync();
            return category.Name;
        }

        public async Task<string> SafeDeleteToDoAsync(Guid todoId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unıtOfWork.GetRepository<ToDo>().GetByGuidAsync(todoId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            category.Status = "Tamamlanmadı";
            await _unıtOfWork.GetRepository<ToDo>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> UndoDeleteToDoAsync(Guid todoId)
        {
            var category = await _unıtOfWork.GetRepository<ToDo>().GetByGuidAsync(todoId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;
            category.Status = "Tamamlanmadı";
            await _unıtOfWork.GetRepository<ToDo>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> UpdateToDoAsync(ToDoUpdateDto toDoUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unıtOfWork.GetRepository<ToDo>().GetAsync(x => !x.IsDeleted && x.ToDoID == toDoUpdateDto.ToDoID);

            category.Name = toDoUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;
            await _unıtOfWork.GetRepository<ToDo>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }
    }
}
