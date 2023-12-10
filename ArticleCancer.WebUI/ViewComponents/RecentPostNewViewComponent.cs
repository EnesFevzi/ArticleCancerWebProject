using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NewCancer.Infrastructure.Services.Abstract;

namespace ArticleCancer.WebUI.ViewComponents
{
    public class RecentPostNewViewComponent : ViewComponent
    {
        private readonly INewService _newService;

        public RecentPostNewViewComponent(INewService newService)
        {
            _newService = newService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _newService.GetAllNewsNonDeletedTake3Async();
            return View(articles);
        }
    }
}
