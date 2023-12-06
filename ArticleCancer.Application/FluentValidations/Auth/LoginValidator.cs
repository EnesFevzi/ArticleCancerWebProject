using ArticleCancer.Application.DTOs.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.Auth
{
    public class LoginValidator : AbstractValidator<UserLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Kullanıcı Adı");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Email");
        }
    }
}
