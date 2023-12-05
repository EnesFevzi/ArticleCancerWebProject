using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashbordService;

        public DashboardController(IDashboardService dashbordService)
        {
            _dashbordService = dashbordService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await _dashbordService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> YearlyArticleCountsByUser()
        {
            var count = await _dashbordService.GetYearlyArticleByUserCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await _dashbordService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCountByUser()
        {
            var count = await _dashbordService.GetTotalArticleCountByUser();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalNewCount()
        {
            var count = await _dashbordService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalNewCountByUser()
        {
            var count = await _dashbordService.GetTotalNewCountByUser();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await _dashbordService.GetTotalCategoryCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalUserCounts()
        {
            var count = await _dashbordService.GetTotalUserCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalRoleCounts()
        {
            var count = await _dashbordService.GetTotalRoleCount();
            return Json(count);
        }

    }
}
