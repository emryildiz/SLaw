using FluentValidation;
using SLaw.Application.Features.Commands.PracticeAreas.Create;

namespace SLaw.Application.Validators.PracticeAreas
{
    public class CreatePracticeAreaValidator : AbstractValidator<CreatePracticeAreaCommandRequest>
    {
        public CreatePracticeAreaValidator()
        {
            this.RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olabilir.")
                .MaximumLength(30).WithMessage("{PropertyName} en fazla 30 karakter olabilir.");

            this.RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(10).WithMessage("{PropertyName} en az 10 karakter olabilir.")
                .MaximumLength(50000).WithMessage("{PropertyName} en fazla 50000 karakter olabilir.");
        }
    }
}
