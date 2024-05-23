using FluentValidation;
using FreelApp.Application.Commands.CreateComment;
using FreelApp.Application.Commands.CreateProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelApp.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                 .MinimumLength(10)
                 .WithMessage("Título deve ter mais que 10 caracteres");

            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Descrição é de 255 caracteres");
        }
    }
}
