using ArticleCancer.Application.DTOs.Announcements;
using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Consts;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.ResultMessages;
using ArticleCancer.Infrastructure.Services.Abstract;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = $"{RoleConsts.Admin}")]
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
		public async Task<IActionResult> Index()
		{
			var articles = await _announcementService.GetAllAnnouncementsNonDeletedAsync();
			return View(articles);
		}
		[HttpGet]
		public async Task<IActionResult> DeletedAnnouncement()
		{
			var articles = await _announcementService.GetAllAnnouncementsDeletedAsync();
			return View(articles);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(AnnouncementAddDto announcementAddDto)
		{
			var map = _mapper.Map<Announcement>(announcementAddDto);
			var result = await _validator.ValidateAsync(map);
			var result2 = await _addvalidator.ValidateAsync(announcementAddDto);

			if (!result.IsValid && !result2.IsValid)
			{
				result.AddToModelState(this.ModelState);

			}
			else
			{
				await _announcementService.CreateAnnouncementAsync(announcementAddDto);
				_toastNotification.AddSuccessToastMessage(Messages.Announcement.Add(announcementAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Announcement", new { Area = "Admin" });

			}
			return View();

		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid announcementId)
		{
			var article = await _announcementService.GetAnnouncementNonDeletedAsync(announcementId);
			var articleUpdateDto = _mapper.Map<AnnouncementUpdateDto>(article);
			return View(articleUpdateDto);
		}
		[HttpPost]
		public async Task<IActionResult> Update(AnnouncementUpdateDto announcementUpdateDto)
		{
			var map = _mapper.Map<Announcement>(announcementUpdateDto);
			var result = await _validator.ValidateAsync(map);
			if (!result.IsValid)
			{
				result.AddToModelState(this.ModelState);

			}
			else
			{
				var title = await _announcementService.UpdateAnnouncementAsync(announcementUpdateDto);
				_toastNotification.AddSuccessToastMessage(Messages.Announcement.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
			}


			return View(announcementUpdateDto);
		}

		public async Task<IActionResult> Delete(Guid announcementId)
		{
			var title = await _announcementService.SafeDeleteAnnouncementAsync(announcementId);
			_toastNotification.AddInfoToastMessage(Messages.Announcement.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
		}
        public async Task<IActionResult> HardDelete(Guid announcementId)
        {
            var title = await _announcementService.HardDeleteAnnouncementAsync(announcementId);
            _toastNotification.AddInfoToastMessage(Messages.Announcement.HardDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid announcementId)
		{
			var title = await _announcementService.UndoDeleteAnnouncementAsync(announcementId);
			_toastNotification.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Announcement", new { Area = "Admin" });
		}
	}
}
