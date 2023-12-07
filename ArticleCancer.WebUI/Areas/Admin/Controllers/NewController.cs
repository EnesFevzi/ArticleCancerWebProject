using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Application.DTOs.News;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.ResultMessages;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NewCancer.Infrastructure.Services.Abstract;
using NToastNotify;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewController : Controller
    {
        private readonly INewService _newService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<New> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;


        public NewController(INewService newService, ICategoryService categoryService, IValidator<New> validator, IMapper mapper, IToastNotification toastNotification

            )
        {
            _newService = newService;
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;

        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Index()
        {
            var articles = await _newService.GetAllNewsWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> DeletedNew()
        {
            var articles = await _newService.GetAllNewsWithCategoryDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new NewAddDto { Categories = categories });
        }
        [HttpPost]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Add(NewAddDto newAddDto)
        {
            var map = _mapper.Map<New>(newAddDto);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                await _newService.CreateNewAsync(newAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.New.Add(newAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "New", new { Area = "Admin" });

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });

        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Update(Guid newId)
        {
            var article = await _newService.GetNewWithCategoryNonDeletedAsync(newId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
        [HttpPost]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(NewUpdateDto newUpdateDto)
        {
            var map = _mapper.Map<New>(newUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var title = await _newService.UpdateNewAsync(newUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "New", new { Area = "Admin" });
            }


            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            newUpdateDto.Categories = categories;
            return View(newUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid newId)
        {
            var title = await _newService.SafeDeleteNewAsync(newId);
            _toastNotification.AddInfoToastMessage(Messages.New.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "New", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid newId)
        {
            var title = await _newService.UndoDeleteNewAsync(newId);
            _toastNotification.AddSuccessToastMessage(Messages.New.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "New", new { Area = "Admin" });
        }
    }
}
