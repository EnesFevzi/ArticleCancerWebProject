using ArticleCancer.Application.DTOs.News;

namespace NewCancer.Infrastructure.Services.Abstract
{
    public interface INewService
    {
        Task<List<NewDto>> GetAllNewsAsync();
        Task<List<NewDto>> GetAllNewsWithCategoryNonDeletedAsync();

        Task<List<NewDto>> GetAllNewsWithCategoryDeletedAsync();
        Task<NewDto> GetNewWithCategoryNonDeletedAsync(Guid articleID);
        Task CreateNewAsync(NewAddDto newAddDto);
        Task<string> UpdateNewAsync(NewUpdateDto newUpdateDto);
        Task<string> SafeDeleteNewAsync(Guid articleID);
        Task<string> UndoDeleteNewAsync(Guid articleID);
        Task<NewListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<NewListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);

        Task<NewDto> GetNewDetailAsync(Guid articleId, string ipAddress);

        Task<List<NewDto>> GetAllNewsNonDeletedTake3Async();
    }
}
