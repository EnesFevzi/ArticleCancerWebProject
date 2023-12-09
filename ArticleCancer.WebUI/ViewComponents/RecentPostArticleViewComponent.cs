using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.ViewComponents
{
    public class RecentPostArticleViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public RecentPostArticleViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _articleService.GetAllArticlesNonDeletedTake3Async();
            return View(articles);
        }
    }
}
