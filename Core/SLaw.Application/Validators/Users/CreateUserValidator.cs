using FluentValidation;
using SLaw.Application.Features.Commands.Users.Create;

namespace SLaw.Application.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserValidator()
        {
            this.RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olabilir.")
                .MaximumLength(15).WithMessage("{PropertyName} en fazla 15 karakter olabilir.");

            this.RuleFor(c => c.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olabilir.")
                .MaximumLength(15).WithMessage("{PropertyName} en fazla 15 karakter olabilir.");

            this.RuleFor(c => c.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(4).WithMessage("{PropertyName} en az 4 karakter olabilir.")
                .MaximumLength(15).WithMessage("{PropertyName} en fazla 15 karakter olabilir.");

            this.RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçersiz eposta adresi girdiniz.");

            this.RuleFor(c => c.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(6).WithMessage("{PropertyName} en az 4 karakter olabilir.")
                .MaximumLength(15).WithMessage("{PropertyName} en fazla 15 karakter olabilir.");
        }
    }
}
