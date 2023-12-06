using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<int> GetTotalArticleCount();
        Task<int> GetTotalCategoryCount();
        Task<int> GetTotalNewCount();
        Task<int> GetTotalVideoCount();
        Task<int> GetTotalUserCount();
        Task<int> GetTotalRoleCount();
    }
}
