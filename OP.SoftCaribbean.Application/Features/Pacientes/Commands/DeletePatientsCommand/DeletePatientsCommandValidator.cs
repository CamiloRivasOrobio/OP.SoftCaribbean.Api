using FluentValidation;

namespace OP.SoftCaribbean.Application.Features.Pacientes.Commands.DeletePatientsCommand
{
    public class DeletePatientsCommandValidator : AbstractValidator<DeletePatientsCommand>
    {
        public DeletePatientsCommandValidator()
        {
            RuleFor(p => p.nmid)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}