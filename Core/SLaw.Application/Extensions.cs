using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using SLaw.Application.Validators.Lawyers;

namespace SLaw.Application
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            Assembly assm = Assembly.GetExecutingAssembly();

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateLawyerValidator>();

            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(assm));
            services.AddAutoMapper(assm);
        }
    }
}
