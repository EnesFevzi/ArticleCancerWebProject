using ArticleCancer.Application.Models.Emails;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Services.Abstract;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NToastNotify;

namespace ArticleCancer.WebUI.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ISendMailService _sendMailService;
        private readonly IToastNotification _toastNotification;

        public ResetPasswordController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ISendMailService sendMailService, IToastNotification toastNotification)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _sendMailService = sendMailService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassword forgetPassword)
        {
            if (!ModelState.IsValid)
            {
                _toastNotification.AddErrorToastMessage("Böyle Bir Kullanıcı Bulunamadı ", new ToastrOptions { Title = "İşlem Başarısız" });
                ModelState.AddModelError("", "Böyle Bir Kullanıcı Bulunamadı");
                return View();
            }

            var user = await userManager.FindByEmailAsync(forgetPassword.Mail);
            if (user != null)
            {
                string passwordResetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "ResetPassword", new
                {
                    Area = " ",
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);


                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Portfolyo Project İletişim", "portfolyoproject@gmail.com");

                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("Kullanıcı", forgetPassword.Mail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Aşağıdaki linke tıklayarak şifrenizi sıfırlayabilirsiniz..." + passwordResetTokenLink;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Şifre Değişiklik Talebi";

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("portfolyoproject@gmail.com", "wajrzicyhixvymug");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
                _toastNotification.AddSuccessToastMessage("Lütfen mailinizi kontrol ediniz. ", new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Login", "Auth", new { Area = " " });

            }
            else
            {
                _toastNotification.AddErrorToastMessage("Böyle Bir Kullanıcı Bulunamadı ", new ToastrOptions { Title = "İşlem Başarısız" });
                ModelState.AddModelError("", "Böyle Bir Kullanıcı Bulunamadı");
                return View();
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword(Guid userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //hata mesajı
            }
            var user = await userManager.FindByIdAsync(userid.ToString());
            var result = await userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Auth",new { Area = " " });
            }
            return View();
        }
    }
}
