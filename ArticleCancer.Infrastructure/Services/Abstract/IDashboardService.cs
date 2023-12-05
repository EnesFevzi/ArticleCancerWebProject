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
        Task<List<int>> GetYearlyArticleByUserCounts();
        Task<int> GetTotalArticleCount();
        Task<int> GetTotalArticleCountByUser();
        Task<int> GetTotalCategoryCount();
        Task<int> GetTotalCategoryCountByUser();
        Task<int> GetTotalNewCount();
        Task<int> GetTotalNewCountByUser();
        Task<int> GetTotalUserCount();
        Task<int> GetTotalRoleCount();
    }
}
