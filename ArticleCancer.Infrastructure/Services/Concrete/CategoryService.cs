using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnıtOfWork unıtOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }


        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var userEmail = _user.GetLoggedInEmail();
            map.CreatedBy = userEmail;
            await _unıtOfWork.GetRepository<Category>().AddAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24()
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return map.Take(24).ToList();
        }

        public async Task<CategoryDto> GetCategoryByID(Guid id)
        {
            var categories = await _unıtOfWork.GetRepository<Category>().GetAsync(x => x.CategoryID == id);
            var map = _mapper.Map<CategoryDto>(categories);
            return map;
        }

        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unıtOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await _unıtOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {
            var category = await _unıtOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;
            await _unıtOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _unıtOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.CategoryID == categoryUpdateDto.CategoryID);

            category.Name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await _unıtOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unıtOfWork.SaveAsync();

            return category.Name;
        }
    }
}
