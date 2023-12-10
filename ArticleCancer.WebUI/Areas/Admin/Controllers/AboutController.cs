using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Consts;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.ResultMessages;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IValidator<About> _validator;
        private readonly IValidator<AboutAddDto> _addvalidator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;


        public AboutController(IAboutService aboutService, IValidator<About> validator, IValidator<AboutAddDto> addvalidator, IMapper mapper, IToastNotification toastNotification
            )
        {
            _aboutService = aboutService;
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _addvalidator= addvalidator;

        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var articles = await _aboutService.GetAllAboutsAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Add(AboutAddDto aboutAddDto)
        {
            var map = _mapper.Map<About>(aboutAddDto);
            var result = await _validator.ValidateAsync(map);
            var result2 = await _addvalidator.ValidateAsync(aboutAddDto);

            if (!result.IsValid && !result2.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                await _aboutService.CreateAboutAsync(aboutAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Article.Add(aboutAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "About", new { Area = "Admin" });

            }
            return View();

        }
        [HttpGet]
     
        public async Task<IActionResult> Update(Guid aboutId)
        {
            var article = await _aboutService.GetABoutByID(aboutId);
            var articleUpdateDto = _mapper.Map<AboutUpdateDto>(article);
            return View(articleUpdateDto);
        }
        [HttpPost]
       
        public async Task<IActionResult> Update(AboutUpdateDto aboutUpdateDto)
        {
            var map = _mapper.Map<About>(aboutUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

            }
            else
            {
                var title = await _aboutService.UpdateAboutAsync(aboutUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "About", new { Area = "Admin" });
            }
            return View(aboutUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid aboutId)
        {
            var title = await _aboutService.HardDeleteAboutAsync(aboutId);
            _toastNotification.AddInfoToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "About", new { Area = "Admin" });
        }

    }
}
