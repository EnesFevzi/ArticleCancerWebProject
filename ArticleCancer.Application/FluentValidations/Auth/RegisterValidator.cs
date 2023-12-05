using ArticleCancer.Application.DTOs.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.Auth
{
	public class RegisterValidator : AbstractValidator<UserAddDto>
	{
		public RegisterValidator()
		{
			RuleFor(x => x.Email)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.WithName("Email");

			RuleFor(x => x.Password)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(20)
				.WithName("Şifre");

			RuleFor(x => x.ConfirmPassword)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(20)
				.Must((dto, confirmPassword) => confirmPassword == dto.Password)
				.WithMessage("Şifreler uyuşmuyor.");
		}
	}
}
