using ArticleCancer.Application.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedByUserAsync();
        
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedByUserAsync();

        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleID);
        Task<ArticleDto> GetArticleWithCategoryNonDeletedByUserAsync(Guid articleID);

        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleID);
        Task<string> UndoDeleteArticleAsync(Guid articleID);
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<ArticleDto> GetArticleDetailAsync(Guid articleId, string ipAddress);

        Task<List<ArticleDto>> GetAllArticlesNonDeletedTake3Async();
        Task<List<ArticleDto>> GetAllArticlesNonDeletedTake6Async();
    }
}
