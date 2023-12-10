using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IAboutService
    {
        Task<List<AboutDto>> GetAllAboutsAsync();
        Task CreateAboutAsync(AboutAddDto aboutAddDto);
        Task<AboutDto> GetABoutByID(Guid aboutId);
        Task<string> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto);
        Task<string> HardDeleteAboutAsync(Guid aboutId);
    }
}
