using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.SoftCaribbean.Application.Features.DataMaestra.Commands.DeleteDataMasterCommand
{
    public class DeleteDataMasterCommandValidator : AbstractValidator<DeleteDataMasterCommand>
    {
        public DeleteDataMasterCommandValidator()
        {
            RuleFor(p => p.nmdato)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
               .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}.");
        }
    }
}