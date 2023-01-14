using FluentValidation;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Commands.UpdatePatientsCommand
{
    public class UpdatePatientsCommandValidator : AbstractValidator<UpdatePatientsCommand>
    {
        public UpdatePatientsCommandValidator()
        {
            RuleFor(p => p.nmidPersona)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.nmidMedicotra)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

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