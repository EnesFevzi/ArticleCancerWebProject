using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
