using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.Personas.Commands.CreatePeopleCommand
{
    public class CreatePeopleCommandValidator : AbstractValidator<CreatePeopleCommand>
    {
        public CreatePeopleCommandValidator()
        {
            RuleFor(p => p.cddocumento)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.dsnombres)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(60).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.dsapellidos)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(60).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.fenacimiento)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.cdusuario)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}