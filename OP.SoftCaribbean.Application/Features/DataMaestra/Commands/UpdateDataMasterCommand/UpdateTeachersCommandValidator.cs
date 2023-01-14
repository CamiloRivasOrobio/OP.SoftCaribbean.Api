using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Commands.UpdateDataMasterCommand
{
    public class UpdateDataMasterCommandValidator : AbstractValidator<UpdateDataMasterCommand>
    {
        public UpdateDataMasterCommandValidator()
        {
            RuleFor(p => p.nmdato)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.cddato)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.dsddato)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");

            RuleFor(p => p.nmmaestro)
              .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
              .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}