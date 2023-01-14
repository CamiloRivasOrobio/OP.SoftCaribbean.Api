using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Commands.CreatePatientsCommand
{
    public class CreatePatientsCommandValidator : AbstractValidator<CreatePatientsCommand>
    {
        public CreatePatientsCommandValidator()
        {
            //RuleFor(p => p.dseps)
            //   .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
            //   .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            //RuleFor(p => p.dsarl)
            //   .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
            //   .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            //RuleFor(p => p.cdusuario)
            //   .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
            //   .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            //RuleFor(p => p.dscondicion)
            //   .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
            //   .MaximumLength(16).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}