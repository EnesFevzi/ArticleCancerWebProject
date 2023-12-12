using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.ViewComponents
{
    public class AnnouncementBannerViewComponent : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementBannerViewComponent(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _announcementService.GetAllAnnouncementsNonDeletedTake6Async();
            return View(articles);
        }
    }
}
