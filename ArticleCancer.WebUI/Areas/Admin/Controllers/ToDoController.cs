using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Application.DTOs.ToDos;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.ResultMessages;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<ToDo> _validator;
        private readonly IMapper _mapper;

        public ToDoController(IToDoService toDoService, IMapper mapper, IToastNotification toastNotification, IValidator<ToDo> validator)
        {
            _toDoService = toDoService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var todos = await _toDoService.GetAllToDosNonDeletedByUserAsync();
            return View(todos);
        }
        public async Task<IActionResult> ListCompleted()
        {
            var todos = await _toDoService.GetAllCompletedToDosNonDeletedByUserAsync();
            return View(todos);
        }
        public async Task<IActionResult> ListNonCompleted()
        {
            var todos = await _toDoService.GetAllNonCompletedToDosNonDeletedByUserAsync();
            return View(todos);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ToDoAddDto todoAddDto)
        {
            var map = _mapper.Map<ToDo>(todoAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _toDoService.CreateToDoAsync(todoAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.ToDo.Add(todoAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "ToDo", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid toDoID)
        {
            var article = await _toDoService.GetToDoByID(toDoID);
            var articleUpdateDto = _mapper.Map<CategoryUpdateDto>(article);
            return View(articleUpdateDto);
        }
        [HttpPost]

        public async Task<IActionResult> Update(ToDoUpdateDto toDoUpdateDto)
        {
            var map = _mapper.Map<ToDo>(toDoUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var name = await _toDoService.UpdateToDoAsync(toDoUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.ToDo.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "ToDo", new { Area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Delete(Guid toDoID)
        {
            var title = await _toDoService.HardDeleteToDoAsync(toDoID);
            _toastNotification.AddInfoToastMessage(Messages.ToDo.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "ToDo", new { Area = "Admin" });
        }
        public async Task<IActionResult> ChangeStatusCompleted(Guid toDoID)
        {
            var title = await _toDoService.ChangeStatusCompletedAsync(toDoID);
            _toastNotification.AddInfoToastMessage(Messages.ToDo.Completed(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "ToDo", new { Area = "Admin" });
        }
        public async Task<IActionResult> ChangeStatusNonCompleted(Guid toDoID)
        {
            var title = await _toDoService.ChangeStatusNonCompletedAsync(toDoID);
            _toastNotification.AddInfoToastMessage(Messages.ToDo.NonCompleted(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "ToDo", new { Area = "Admin" });
        }
    }
}
