using FluentValidation;
using SLaw.Application.Features.Commands.ContactForms.Create;

namespace SLaw.Application.Validators.ContactForms
{
    public class CreateContactFormValidator : AbstractValidator<CreateContactFormCommandRequest>
    {
        public CreateContactFormValidator()
        {
            this.RuleFor(c => c.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olabilir.")
                .MaximumLength(30).WithMessage("{PropertyName} en fazla 30 karakter olabilir.");

            this.RuleFor(c => c.Message)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(10).WithMessage("{PropertyName} en az 10 karakter olabilir.")
                .MaximumLength(50000).WithMessage("{PropertyName} en fazla 50000 karakter olabilir.");

            this.RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .EmailAddress()
                .WithMessage("Geçerli eposta giriniz.");

            this.RuleFor(c => c.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Telefon numarası 10 karakterden az olamaz")
                .MaximumLength(20).WithMessage("Telefon numarası 20 karakterden fazla olamaz.");
            //TODO
            //.Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d4")).WithMessage("Geçersiz telefon numarası giriniz.");
        }
    }
}
