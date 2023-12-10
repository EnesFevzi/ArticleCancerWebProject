using ArticleCancer.Application.DTOs.Mails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.Mails
{
    public class MailValidator : AbstractValidator<MailRequest>
    {
        public MailValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(150)
               .WithName("İsim");

            RuleFor(x => x.SenderMail)
              .NotEmpty()
              .NotNull()
              .MinimumLength(3)
              .MaximumLength(150)
              .WithName("Mail");

            RuleFor(x => x.Subject)
             .NotEmpty()
             .NotNull()
             .MinimumLength(3)
             .MaximumLength(150)
             .WithName("Konu Başlığı");

            RuleFor(x => x.Message)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(500)
            .WithName("İçerik");
        }
    }
}
