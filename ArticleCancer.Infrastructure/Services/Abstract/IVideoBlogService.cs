using ArticleCancer.Application.DTOs.VideoBlogs;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IVideoBlogService
    {
        Task<List<VideoBlogDto>> GetAllVideoBlogsAsync();
        Task<List<VideoBlogDto>> GetAllVideoBlogsWithCategoryNonDeletedAsync();
        Task<List<VideoBlogDto>> GetAllVideoBlogsWithCategoryDeletedAsync();
        Task<VideoBlogDto> GetVideoBlogWithCategoryNonDeletedAsync(Guid videoBlogID);
        Task CreateVideoBlogAsync(VideoBlogAddDto videoBlogAddDto);
        Task<string> UpdateVideoBlogAsync(VideoBlogUpdateDto articleUpdateDto);
        Task<string> SafeDeleteVideoBlogAsync(Guid videoBlogID);
        Task<string> UndoDeleteVideoBlogAsync(Guid videoBlogID);
        Task<VideoBlogListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<VideoBlogListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<VideoBlogDto> GetVideoBlogDetailAsync(Guid videoBlogID, string ipAddress);

        Task<List<VideoBlogDto>> GetAllVideoBlogsNonDeletedTake3Async();
        Task<List<VideoBlogDto>> GetAllVideoBlogsNonDeletedTake6Async();
    }
}
