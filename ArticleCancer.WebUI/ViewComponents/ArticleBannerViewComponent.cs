using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.ViewComponents
{
    public class ArticleBannerViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public ArticleBannerViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _articleService.GetAllArticlesNonDeletedTake6Async();
            return View(articles);
        }
    }
}
