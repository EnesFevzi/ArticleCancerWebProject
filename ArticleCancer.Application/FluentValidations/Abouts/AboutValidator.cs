using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.Abouts
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
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
    public class AboutAddValidator : AbstractValidator<AboutAddDto>
    {
        public AboutAddValidator()
        {

            RuleFor(x => x.Photo)
                .NotEmpty()
                .WithName("Resim dosyası");

        }
    }
}
