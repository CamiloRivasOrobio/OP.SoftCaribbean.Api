using FluentValidation;

namespace OP.SoftCaribbean.Application.Features.Personas.Commands.UpdatePeopleCommand
{
    public class UpdatePeopleCommandValidator : AbstractValidator<UpdatePeopleCommand>
    {
        public UpdatePeopleCommandValidator()
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