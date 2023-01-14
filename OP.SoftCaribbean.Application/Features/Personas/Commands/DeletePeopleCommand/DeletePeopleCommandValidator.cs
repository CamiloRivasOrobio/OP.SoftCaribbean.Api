using FluentValidation;

namespace OP.SoftCaribbean.Application.Features.Personas.Commands.DeletePeopleCommand
{
    public class DeletePeopleCommandValidator : AbstractValidator<DeletePeopleCommand>
    {
        public DeletePeopleCommandValidator()
        {
            RuleFor(p => p.nmid)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}