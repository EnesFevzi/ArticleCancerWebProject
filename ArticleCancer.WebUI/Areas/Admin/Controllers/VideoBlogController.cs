using ArticleCancer.Application.DTOs.VideoBlogs;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.ResultMessages;
using ArticleCancer.Infrastructure.Services.Abstract;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoBlogController : Controller
    {
        private readonly IVideoBlogService _videoBlogService;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<VideoBlog> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;


        public VideoBlogController(IVideoBlogService videoBlogService, ICategoryService categoryService, IValidator<VideoBlog> validator, IMapper mapper, IToastNotification toastNotification

            )
        {
            _videoBlogService = videoBlogService;
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;

        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Index()
        {
            var articles = await _videoBlogService.GetAllVideoBlogsWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> DeletedVideoBlog()
        {
            var articles = await _videoBlogService.GetAllVideoBlogsWithCategoryDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new VideoBlogAddDto { Categories = categories });
        }
        [HttpPost]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Add(VideoBlogAddDto articleAddDto)
        {
            var map = _mapper.Map<VideoBlog>(articleAddDto);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                await _videoBlogService.CreateVideoBlogAsync(articleAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.VideoBlog.Add(articleAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "VideoBlog", new { Area = "Admin" });

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new VideoBlogAddDto { Categories = categories });

        }
        [HttpGet]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
        public async Task<IActionResult> Update(Guid videoBlogId)
        {
            var article = await _videoBlogService.GetVideoBlogWithCategoryNonDeletedAsync(videoBlogId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDto = _mapper.Map<VideoBlogUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }
        [HttpPost]
        //[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(VideoBlogUpdateDto articleUpdateDto)
        {
            var map = _mapper.Map<VideoBlog>(articleUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var title = await _videoBlogService.UpdateVideoBlogAsync(articleUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.VideoBlog.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "VideoBlog", new { Area = "Admin" });
            }


            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid videoBlogId)
        {
            var title = await _videoBlogService.SafeDeleteVideoBlogAsync(videoBlogId);
            _toastNotification.AddInfoToastMessage(Messages.VideoBlog.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "VideoBlog", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid videoBlogId)
        {
            var title = await _videoBlogService.UndoDeleteVideoBlogAsync(videoBlogId);
            _toastNotification.AddSuccessToastMessage(Messages.VideoBlog.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "VideoBlog", new { Area = "Admin" });
        }
    }
}
