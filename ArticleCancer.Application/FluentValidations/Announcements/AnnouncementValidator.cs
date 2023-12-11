using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Application.DTOs.Announcements;
using ArticleCancer.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.Announcements
{
	public class AnnouncementValidator : AbstractValidator<Announcement>
	{
		public AnnouncementValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(150)
				.WithName("Başlık");

			RuleFor(x => x.Content)
			   .NotEmpty()
			   .NotNull()
			   .MinimumLength(3)
			   .MaximumLength(150)
			   .WithName("İçerik");


		}
	}
	public class AnnouncementAddValidator : AbstractValidator<AnnouncementAddDto>
	{
		public AnnouncementAddValidator()
		{

			RuleFor(x => x.Photo)
				.NotEmpty()
				.WithName("Resim dosyası");

		}
	}
}
