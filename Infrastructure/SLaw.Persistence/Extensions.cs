using Microsoft.Extensions.DependencyInjection;
using SLaw.Application.Repositories.About;
using SLaw.Application.Repositories.ContactForms;
using SLaw.Application.Repositories.Lawyers;
using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Persistence.Repository.About;
using SLaw.Persistence.Repository.ContactForms;
using SLaw.Persistence.Repository.Lawyers;
using SLaw.Persistence.Repository.PracticeAreas;

namespace SLaw.Persistence
{
    public static class Extensions
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ILawyerWriteRepository, LawyerWriteRepository>();
            services.AddScoped<ILawyerReadRepository, LawyerReadRepository>();

            services.AddScoped<IPracticeAreaReadRepository, PracticeAreaReadRepository>();
            services.AddScoped<IPracticeAreaWriteRepository, PracticeAreaWriteRepository>();

            services.AddScoped<IContactFormWriteRepository, ContactFormWriteRepository>();
            services.AddScoped<IContactFormReadRepository, ContactFormReadRepository>();

            services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
            services.AddScoped<IAboutReadRepository, AboutReadRepository>();
        }
    }
}
