using ArticleCancer.Domain.Entities;
using FluentValidation;

namespace ArticleCancer.Application.FluentValidations.News
{
    public class NewValidator : AbstractValidator<New>
    {
        public NewValidator()
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
