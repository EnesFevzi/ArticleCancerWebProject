using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task< IActionResult> Index()
        {
            var abouts =await _aboutService.GetAllAboutsAsync();
            return View(abouts);
        }
    }
}
