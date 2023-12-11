using ArticleCancer.Application.DTOs.Announcements;
using ArticleCancer.Application.DTOs.Articles;
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
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IValidator<Announcement> _validator;
		private readonly IValidator<AnnouncementAddDto> _addvalidator;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastNotification;


		public AnnouncementController(IAnnouncementService announcementService, IValidator<Announcement> validator, IMapper mapper, IToastNotification toastNotification, IValidator<AnnouncementAddDto> addvalidator

			)
		{
			_announcementService = announcementService;
			_validator = validator;
			_mapper = mapper;
			_toastNotification = toastNotification;
			_addvalidator = addvalidator;

		}
		[HttpGet]
		//[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
		public async Task<IActionResult> Index()
		{
			var articles = await _announcementService.GetAllAnnouncementsNonDeletedAsync();
			return View(articles);
		}
		[HttpGet]
		//[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
		public async Task<IActionResult> DeletedAnnouncement()
		{
			var articles = await _announcementService.GetAllAnnouncementsDeletedAsync();
			return View(articles);
		}
		[HttpGet]
		//[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
		public async Task<IActionResult> Add()
		{
			return View();
		}
		[HttpPost]
		//[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
		public async Task<IActionResult> Add(AnnouncementAddDto articleAddDto)
		{
			var map = _mapper.Map<Announcement>(articleAddDto);
			var result = await _validator.ValidateAsync(map);

			if (!result.IsValid)
			{
				result.AddToModelState(this.ModelState);

			}
			else
			{
				await _announcementService.CreateAnnouncementAsync(articleAddDto);
				_toastNotification.AddSuccessToastMessage(Messages.Announcement.Add(articleAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Announcement", new { Area = "Admin" });

			}
			return View();

		}
		[HttpGet]
		//[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Member}")]
		public async Task<IActionResult> Update(Guid articleId)
		{
			var article = await _announcementService.GetAnnouncementNonDeletedAsync(articleId);
			var articleUpdateDto = _mapper.Map<AnnouncementUpdateDto>(article);
			return View(articleUpdateDto);
		}
		[HttpPost]
		//[Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Admin}")]
		public async Task<IActionResult> Update(AnnouncementUpdateDto articleUpdateDto)
		{
			var map = _mapper.Map<Announcement>(articleUpdateDto);
			var result = await _validator.ValidateAsync(map);
			if (!result.IsValid)
			{
				result.AddToModelState(this.ModelState);

			}
			else
			{
				var title = await _announcementService.UpdateAnnouncementAsync(articleUpdateDto);
				_toastNotification.AddSuccessToastMessage(Messages.Announcement.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
			}


			return View(articleUpdateDto);
		}

		public async Task<IActionResult> Delete(Guid articleId)
		{
			var title = await _announcementService.SafeDeleteAnnouncementAsync(articleId);
			_toastNotification.AddInfoToastMessage(Messages.Announcement.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
		}

		public async Task<IActionResult> UndoDelete(Guid articleId)
		{
			var title = await _announcementService.UndoDeleteAnnouncementAsync(articleId);
			_toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
		}
	}
}
