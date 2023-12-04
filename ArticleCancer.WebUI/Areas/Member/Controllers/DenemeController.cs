using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
