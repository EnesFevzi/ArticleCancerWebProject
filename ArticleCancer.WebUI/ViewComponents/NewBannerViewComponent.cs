using Microsoft.AspNetCore.Mvc;
using NewCancer.Infrastructure.Services.Abstract;

namespace ArticleCancer.WebUI.ViewComponents
{
    public class NewBannerViewComponent:ViewComponent
    {
        private readonly INewService _newService;

        public NewBannerViewComponent(INewService newService)
        {
            _newService = newService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _newService.GetAllNewsNonDeletedTake6Async();
            return View(articles);
        }
    }
}
