using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.Areas.Admin.ViewComponents
{
    public class DashboardWeatherViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public DashboardWeatherViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weatherInfo = await _userService.GetWeatherInfo();
            return View(weatherInfo);
        }
    }
}
