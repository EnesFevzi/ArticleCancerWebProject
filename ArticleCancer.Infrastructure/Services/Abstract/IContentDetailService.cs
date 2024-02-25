using ArticleCancer.Application.DTOs.ApplicationUsers;
using ArticleCancer.Application.DTOs.ContentDetails;
using ArticleCancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IContentDetailService
    {
        Task<List<ContentDetailDto>> GetAllApplicationUsersAsync();
        Task<Guid> CreateContentDetailAsync(AppUser appUser,string contentType);
        Task<ContentDetailDto> GetContentDetailByID(Guid contentDetailId);
        Task<string> UpdateContentDetailAsync(Guid contentDetailId);
        Task<string> UpdateContentDetailLoginTimeAsync(Guid contentDetailId);
        Task<string> HardDeleteContentDetailAsync(Guid contentDetailId);
        Task<string> UpdateContentDetailIsWatchAsync(Guid contentDetailId);
    }
}
