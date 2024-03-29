﻿using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Filter.ArticleVisitors;
using ArticleCancer.Infrastructure.Filter.NewVisitors;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewCancer.Infrastructure.Services.Abstract;

namespace ArticleCancer.WebUI.Controllers
{
    [ServiceFilter(typeof(NewVisitorFilter))]
    public class NewController : Controller
    {
        private readonly INewService _newService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IContentDetailService _contentDetailService;

        public NewController(INewService newService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnıtOfWork unıtOfWork, IContentDetailService contentDetailService)
        {
            _newService = newService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unıtOfWork = unıtOfWork;
            _contentDetailService = contentDetailService;
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
            var articles = await _newService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            keyword = keyword.ToLower();
            var articles = await _newService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {

                string userName = User.Identity.Name;


                var appUser = await _unıtOfWork.GetRepository<AppUser>().GetAsync(u => u.UserName == userName);

                if (appUser != null)
                {

                    var contentDetailId = await _contentDetailService.CreateContentDetailAsync(appUser, "Blog");
                    TempData["contentDetailId"] = contentDetailId.ToString();

                }
            }
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            var articleDetail = await _newService.GetNewDetailAsync(id, ipAddress);

            if (articleDetail == null)
            {
                return NotFound();
            }

            return View(articleDetail);
        }
    }
}
