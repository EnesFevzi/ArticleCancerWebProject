using ArticleCancer.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.ToDos
{
    public class ToDoValidator:AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            RuleFor(todo => todo.Name)
            .NotEmpty().WithMessage("Görev adı boş olamaz.")
            .MaximumLength(255).WithMessage("Görev adı en fazla 255 karakter olmalıdır.");

           


        }
    }
}
