using ArticleCancer.Application.DTOs.Mails;
using ArticleCancer.Infrastructure.Services.Abstract;
using AutoMapper.Internal;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ArticleCancer.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISendMailService _sendMailService;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<MailRequest> _validator;

        public ContactController(ISendMailService sendMailService, IToastNotification toastNotification, IValidator<MailRequest> validator)
        {
            _sendMailService = sendMailService;
            _toastNotification = toastNotification;
            _validator = validator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MailRequest mailRequest)
        {
            var result = await _validator.ValidateAsync(mailRequest);
            if (result.IsValid)
            {
                var ısMailSend = await _sendMailService.SendContactMail(mailRequest);
                if (ısMailSend)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }

            }
            else
            {
                _toastNotification.AddErrorToastMessage("Mail Gönderme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
            }
            return View();

        }
    }
}
