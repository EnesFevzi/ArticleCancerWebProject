using ArticleCancer.Application.DTOs.Users;
using ArticleCancer.Application.Models.Emails;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Services.Abstract;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUserService _userService;
		private readonly IValidator<UserLoginDto> _loginValidator;
		private readonly IValidator<UserAddDto> _registerValidator;
		private readonly IToastNotification _toastNotification;



		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IValidator<UserLoginDto> loginValidator,IUserService userService, IValidator<UserAddDto> registerValidator, IToastNotification toastNotification)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _loginValidator = loginValidator;
            _userService = userService;
            _registerValidator = registerValidator;
            _toastNotification= toastNotification;
        }

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Register(UserAddDto userAddDto)
		{
			var validator = await _registerValidator.ValidateAsync(userAddDto);

			if (!validator.IsValid)
			{
				validator.AddToModelState(this.ModelState);
			}
			else
			{
				var (result, userEmail) = await _userService.CreateUserAsync(userAddDto);

				if (result.Succeeded)
				{
					_toastNotification.AddSuccessToastMessage("Kayıt işlemi başarıyla tamamlandı. Şimdi giriş yapabilirsiniz.", new ToastrOptions { Title = "İşlem Başarılı" });

					return RedirectToAction("ConfirmEmail", "Auth", new { area = " ", email = userEmail });
				}

				ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
			}

			return View();
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult ConfirmEmail(string email)
		{
			var model = new ConfirmEmailViewModel { Email = email };
			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
		{
			if (ModelState.IsValid)
			{
				bool isConfirmed = await _userService.ConfirmAccount(model.Email, model.ConfirmationCode);

				if (isConfirmed)
				{
					return RedirectToAction("Login", "Auth", new { area = " " });
				}

				ModelState.AddModelError("", "E-posta doğrulama başarısız.");
			}

			return View(model);
		}
		[AllowAnonymous]
		[HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var validator = await _loginValidator.ValidateAsync(userLoginDto);
            if (validator.IsValid)
            {
                var user = await userManager.FindByNameAsync(userLoginDto.Username);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
						return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
					}
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Error404()
        {
            return View();
        }

		
	}
}

