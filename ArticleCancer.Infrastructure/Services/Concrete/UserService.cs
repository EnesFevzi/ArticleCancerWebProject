using ArticleCancer.Application.DTOs.Users;
using ArticleCancer.Application.Models.Weathers;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Domain.Enums;
using ArticleCancer.Infrastructure.Consts;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Security.Claims;
using System.Xml.Linq;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
	public class UserService : IUserService
	{
		private readonly IUnıtOfWork _unitOfWork;
		private readonly IImageHelper _imageHelper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly ClaimsPrincipal _user;

		public UserService(IUnıtOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
		{
			_unitOfWork = unitOfWork;
			_imageHelper = imageHelper;
			_httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
			_mapper = mapper;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		private int GenerateRandomCode()
		{
			Random rnd = new Random();
			return rnd.Next(100000, 1000000);
		}

		private string Mail(string mail)
		{
			return mail;
		}
		public async Task<string> GetMailByUser(AppUser appUser)
		{
			return appUser.Email;
		}

		public async Task<(IdentityResult, string)> CreateUserAsync(UserAddDto userAddDto)
		{
			var map = _mapper.Map<AppUser>(userAddDto);

			var username = userAddDto.Email.Split('@').FirstOrDefault();
			map.UserName = username;

			int confirmationCode = GenerateRandomCode();
			map.ConfirmCode = confirmationCode;

			var createUserResult = await _userManager.CreateAsync(map, userAddDto.Password);

			if (createUserResult.Succeeded)
			{
				bool mailSent = await SendMailConfirm(userAddDto.Email, confirmationCode);

				if (!mailSent)
				{
					await _userManager.DeleteAsync(map);
					return (IdentityResult.Failed(new IdentityError { Description = "Onay maili gönderilemedi." }), null);
				}

				var addToRoleResult = await _userManager.AddToRoleAsync(map, RoleConsts.Member);

				if (!addToRoleResult.Succeeded)
				{
					await _userManager.DeleteAsync(map);
					return (addToRoleResult, null);
				}

				return (IdentityResult.Success, userAddDto.Email);
			}

			return (createUserResult, null);
		}
		public async Task<bool> ConfirmAccount(string mail, int confirmationCode)
		{
			var user = await _userManager.FindByEmailAsync(mail);

			if (user != null && user.ConfirmCode == confirmationCode)
			{
				user.EmailConfirmed = true;

				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return true;
				}
				else
				{
					
					return false;
				}
			}

			return false;
		}
		public Task<bool> SendMailConfirm(string mail, int confirmationCode)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Portfolyo Project İletişim", "portfolyoproject@gmail.com");

			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("Yeni Blog Üyesi", mail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = "Kayıt İşlemini Gerçekleştirmek İçin Onay Kodunuz: " + confirmationCode;
			mimeMessage.Body = bodyBuilder.ToMessageBody();
			mimeMessage.Subject = "Meme Kanseri Blog Sitesi Mail Onay Kodu" ;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("portfolyoproject@gmail.com", "wajrzicyhixvymug");
			client.Send(mimeMessage);
			client.Disconnect(true);
			return Task.FromResult(true);
		}


		public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
		{
			var user = await GetAppUserByIdAsync(userId);
			var result = await _userManager.DeleteAsync(user);
			if (result.Succeeded)
				return (result, user.Email);
			else
				return (result, null);
		}

		public async Task<List<AppRole>> GetAllRolesAsync()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return roles;
		}

		public async Task<List<UserListDto>> GetAllUsersWithRoleAsync()
		{
			var users = await _userManager.Users.ToListAsync();
			var map = _mapper.Map<List<UserListDto>>(users);

			foreach (var item in map)
			{
				var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
				var role = string.Join("", await _userManager.GetRolesAsync(findUser));
				item.Role = role;
			}

			return map;
		}

		public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
		{
			return await _userManager.FindByIdAsync(userId.ToString());
		}

		public async Task<UserProfileDto> GetUserProfileAsync()
		{
			var userID = _user.GetLoggedInUserId();
			var getImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userID, x => x.Image);
			var map = _mapper.Map<UserProfileDto>(getImage);
			map.Image.FileName = getImage.Image.FileName;
			return map;
		}

		public async Task<UserDto> GetUserProfileAsyncWitRoleAsync()
		{
			var userID = _user.GetLoggedInUserId();
			var user = await GetAppUserByIdAsync(userID);
			var getImage = await _unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userID, x => x.Image);
			var role = string.Join("", await GetUserRoleAsync(user));
			var map = _mapper.Map<UserDto>(getImage);
			map.Image.FileName = getImage.Image.FileName;
			map.Role = role;
			return map;
		}

		public async Task<string> GetUserRoleAsync(AppUser user)
		{
			return string.Join("", await _userManager.GetRolesAsync(user));
		}

		public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
		{
			var user = await GetAppUserByIdAsync(userUpdateDto.Id);
			var userRole = await GetUserRoleAsync(user);

			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				await _userManager.RemoveFromRoleAsync(user, userRole);
				var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
				await _userManager.AddToRoleAsync(user, findRole.Name);
				return result;
			}
			else
				return result;
		}

		public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
		{
			var userId = _user.GetLoggedInUserId();
			var user = await GetAppUserByIdAsync(userId);

			if (userProfileDto.CurrentPassword != null)
			{
				var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
				if (isVerified && userProfileDto.NewPassword != null)
				{
					var result = await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
					if (result.Succeeded)
					{
						await _userManager.UpdateSecurityStampAsync(user);
						await _signInManager.SignOutAsync();
						await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

						_mapper.Map(userProfileDto, user);

						if (userProfileDto.Photo != null)
							user.ImageID = await UploadImageForUser(userProfileDto);

						await _userManager.UpdateAsync(user);
						return true;
					}
					else
						return false;
				}
				else if (isVerified)
				{
					await _userManager.UpdateSecurityStampAsync(user);
					_mapper.Map(userProfileDto, user);

					if (userProfileDto.Photo != null)
						user.ImageID = await UploadImageForUser(userProfileDto);

					await _userManager.UpdateAsync(user);

					return true;
				}
				else
					return false;
			}
			else
			{
				return false;
			}
		}

		private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
		{
			var userEmail = _user.GetLoggedInEmail();

			var imageUpload = await _imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
			Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
			await _unitOfWork.GetRepository<Image>().AddAsync(image);

			return image.ImageID;
		}

        public async Task<WeatherInfo> GetWeatherInfo()
        {
            string api = "64d476e683236d625b8f0a39392c240a";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            var temperature = decimal.Parse(document.Descendants("temperature").ElementAt(0).Attribute("value").Value);

            temperature = Math.Round(temperature);

            string condition = string.Empty;

            if (temperature >= 30)
            {
                condition = "Bugün hava çok sıcak!";
            }
            else if (temperature >= 20)
            {
                condition = "Bugün hava ılıman.";
            }
            else if (temperature >= 10)
            {
                condition = "Bugün hava serin.";
            }
            else
            {
                condition = "Bugün hava soğuk.";
            }

            return new WeatherInfo
            {
                Condition = condition,
                Temperature = temperature
            };
        }

        public async Task<IdentityResult> CreateUserAsyncByAdmin(UserAddDto2 userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
                return result;
        }
    }
}
