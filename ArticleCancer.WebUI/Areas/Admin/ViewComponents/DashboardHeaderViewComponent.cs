using ArticleCancer.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly IUserService userService;
        public DashboardHeaderViewComponent(IUserService userService)
        {

            this.userService = userService;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userService.GetUserProfileAsyncWitRoleAsync();
            return View(user);
        }
    }
}
