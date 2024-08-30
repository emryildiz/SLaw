using FluentValidation;
using SLaw.Application.Features.Commands.PracticeAreas.Update;

namespace SLaw.Application.Validators.PracticeAreas
{
    public class UpdatePracticeAreaValidator : AbstractValidator<UpdatePracticeAreaCommandRequest>
    {
        public UpdatePracticeAreaValidator()
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
