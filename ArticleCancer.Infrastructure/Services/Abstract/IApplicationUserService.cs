using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Application.DTOs.ApplicationUsers;
using ArticleCancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUserDto>> GetAllApplicationUsersAsync();
        Task <Guid> CreateApplicationUserAsync(AppUser appUser);
        Task<ApplicationUserDto> GetApplicationUserByID(Guid applicationUserId);
        Task<string> UpdateApplicationUserAsync(Guid applicationUserId);
        Task<string> UpdateApplicationUserLoginTimeAsync(Guid applicationUserID);
        Task<string> HardDeleteApplicationUserAsync(Guid applicationUserId);
    }
}
