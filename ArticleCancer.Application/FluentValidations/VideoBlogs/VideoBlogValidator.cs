using ArticleCancer.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.VideoBlogs
{
    public class VideoBlogValidator : AbstractValidator<VideoBlog>
    {
        public VideoBlogValidator()
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

            RuleFor(x => x.CategoryID)
               .NotEmpty()
               .NotNull()
               .WithName("Kategori");

        }
    }
}
