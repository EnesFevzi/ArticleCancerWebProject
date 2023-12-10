using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NewCancer.Infrastructure.Services.Abstract;

namespace ArticleCancer.WebUI.ViewComponents
{
    public class VideoBlogBannerViewComponent : ViewComponent
    {
        private readonly IVideoBlogService _videoBlogService;

        public VideoBlogBannerViewComponent(IVideoBlogService videoBlogService)
        {
            _videoBlogService = videoBlogService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _videoBlogService.GetAllVideoBlogsNonDeletedTake6Async();
            return View(articles);
        }
    }
}
