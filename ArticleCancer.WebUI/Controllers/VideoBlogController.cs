using ArticleCancer.Infrastructure.Filter.NewVisitors;
using ArticleCancer.Infrastructure.Filter.VideoBlogVisitors;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewCancer.Infrastructure.Services.Abstract;

namespace ArticleCancer.WebUI.Controllers
{
    [ServiceFilter(typeof(VideoBlogVisitorFilter))]
    public class VideoBlogController : Controller
    {
        private readonly IVideoBlogService _videoblogService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnıtOfWork _unıtOfWork;

        public VideoBlogController(IVideoBlogService videoblogService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnıtOfWork unıtOfWork)
        {
            _videoblogService = videoblogService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unıtOfWork = unıtOfWork;
        }
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            string cookieName = "ArticleCancer";
            var httpContext = _httpContextAccessor.HttpContext;

            string cookieValue = httpContext.Request.Cookies[cookieName];

            if (string.IsNullOrEmpty(cookieValue))
            {
                return RedirectToAction("LetsRegister", "Auth", new { Area = " " });
            }
            var articles = await _videoblogService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            keyword = keyword.ToLower();
            var articles = await _videoblogService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            var articleDetail = await _videoblogService.GetVideoBlogDetailAsync(id, ipAddress);

            if (articleDetail == null)
            {
                return NotFound();
            }

            return View(articleDetail);
        }
    }
}
