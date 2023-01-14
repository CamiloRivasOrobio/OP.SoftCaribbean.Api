using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.Maestras.Commands.DeleteTeachersCommand
{
    public class DeleteTeachersCommandValidator : AbstractValidator<DeleteTeachersCommand>
    {
        public DeleteTeachersCommandValidator()
        {
            RuleFor(p => p.nmmaestro)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}