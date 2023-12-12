using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArticleCancer.WebUI.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnıtOfWork _unıtOfWork;

        public HomePageController(IAnnouncementService announcementService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnıtOfWork unıtOfWork)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unıtOfWork = unıtOfWork;
        }

        public async Task<IActionResult> Index(int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            string cookieName = "ArticleCancer";
            var httpContext = _httpContextAccessor.HttpContext;

            string cookieValue = httpContext.Request.Cookies[cookieName];

            if (string.IsNullOrEmpty(cookieValue))
            {
                return RedirectToAction("LetsRegister", "Auth", new { Area = " " });
            }
            var articles = await _announcementService.GetAllByPagingAsync(currentPage, pageSize, isAscending);
            return View(articles);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            var articleDetail = await _announcementService.GetAnnouncementDetailAsync(id, ipAddress);

            if (articleDetail == null)
            {
                return NotFound();
            }

            return View(articleDetail);
        }
    }
}
