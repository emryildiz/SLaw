﻿using FluentValidation;
using SLaw.Application.Features.Commands.Lawyers.Update;

namespace SLaw.Application.Validators.Lawyers
{
    public class UpdateLawyerValidator : AbstractValidator<UpdateLawyerCommandRequest>
    {
        public UpdateLawyerValidator()
        {
            this.RuleFor(l => l.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.");

            this.RuleFor(l => l.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.");

            this.RuleFor(l => l.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.")
                .EmailAddress()
                .WithMessage("Geçerli eposta giriniz.");

            this.RuleFor(l => l.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} boş bırakılamaz.");

            this.RuleFor(l => l.CellPhone)
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
