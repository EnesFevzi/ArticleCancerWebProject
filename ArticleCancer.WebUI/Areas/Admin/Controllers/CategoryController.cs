using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Consts;
using ArticleCancer.Infrastructure.ResultMessages;
using ArticleCancer.Infrastructure.Services.Abstract;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IToastNotification toastNotification, IValidator<Category> validator)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });

                return Json(Messages.Category.Add(categoryAddDto.Name));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryID)
        {
            var article = await _categoryService.GetCategoryByID(categoryID);
            var articleUpdateDto = _mapper.Map<CategoryUpdateDto>(article);
            return View(articleUpdateDto);
        }
        [HttpPost]

        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = _mapper.Map<Category>(categoryUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var name = await _categoryService.UpdateCategoryAsync(categoryUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Delete(Guid categoryID)
        {
            var title = await _categoryService.SafeDeleteCategoryAsync(categoryID);
            _toastNotification.AddInfoToastMessage(Messages.Category.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        public async Task<IActionResult> UndoDelete(Guid categoryID)
        {
            var title = await _categoryService.UndoDeleteCategoryAsync(categoryID);
            _toastNotification.AddSuccessToastMessage(Messages.Category.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
