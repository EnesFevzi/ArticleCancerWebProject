using ArticleCancer.Application.DTOs.Users;
using ArticleCancer.Application.Models.Weathers;
using ArticleCancer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
    public interface IUserService
	{
		Task<List<UserDto>> GetAllUsersWithRoleAsync();
		Task<List<AppRole>> GetAllRolesAsync();
		Task<(IdentityResult, string)> CreateUserAsync(UserAddDto userAddDto);
		Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
		Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
		Task<AppUser> GetAppUserByIdAsync(Guid userId);
		Task<string> GetUserRoleAsync(AppUser user);
		Task<UserProfileDto> GetUserProfileAsync();
		Task<UserDto> GetUserProfileAsyncWitRoleAsync();
		Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
		Task<WeatherInfo> GetWeatherInfo();

        Task<bool> SendMailConfirm(string mail, int confirmationCode);
		Task<bool> ConfirmAccount(string mail, int confirmationCode);
		Task<string> GetMailByUser(AppUser appUser);
	}
}
