﻿using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClaimsPrincipal _user;

        public DashboardService(IUnıtOfWork unıtOfWork, IHttpContextAccessor contextAccessor)
        {
            _unıtOfWork = unıtOfWork;
            _contextAccessor = contextAccessor;
            _user = _contextAccessor.HttpContext.User;
        }

        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await _unıtOfWork.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await _unıtOfWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }

        public async Task<int> GetTotalUserCount()
        {
            var userCount = await _unıtOfWork.GetRepository<AppUser>().CountAsync();
            return userCount;
        }
        public async Task<int> GetTotalRoleCount()
        {
            var userCount = await _unıtOfWork.GetRepository<AppRole>().CountAsync();
            return userCount;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {

            var articles = await _unıtOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;

        }

       

        public async Task<int> GetTotalNewCount()
        {
            var articleCount = await _unıtOfWork.GetRepository<New>().CountAsync();
            return articleCount;
        }

        public async Task<int> GetTotalVideoCount()
        {
            var articleCount = await _unıtOfWork.GetRepository<Video>().CountAsync();
            return articleCount;
        }
    }
}
