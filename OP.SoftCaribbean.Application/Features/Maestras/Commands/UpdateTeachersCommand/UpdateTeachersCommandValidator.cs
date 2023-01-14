using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.Maestras.Commands.UpdateTeachersCommand
{
    public class UpdateTeachersCommandValidator : AbstractValidator<UpdateTeachersCommand>
    {
        public UpdateTeachersCommandValidator()
        {
            RuleFor(p => p.nmmaestro)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.cdmaestro)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(5).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.dsmaestro)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}