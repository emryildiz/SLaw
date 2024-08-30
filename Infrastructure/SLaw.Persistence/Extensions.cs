using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SLaw.Application.Absractions.Services.Authentications;
using SLaw.Application.Absractions.Services.Users;
using SLaw.Application.Repositories.About;
using SLaw.Application.Repositories.ContactForms;
using SLaw.Application.Repositories.Lawyers;
using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities.Identity;
using SLaw.Persistence.Contexts;
using SLaw.Persistence.Repository.About;
using SLaw.Persistence.Repository.ContactForms;
using SLaw.Persistence.Repository.Lawyers;
using SLaw.Persistence.Repository.PracticeAreas;
using SLaw.Persistence.Services.Auth;
using SLaw.Persistence.Services.Users;

namespace SLaw.Persistence
{
    public static class Extensions
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
                                                   {
                                                       options.Password.RequiredLength         = 3;
                                                       options.Password.RequireNonAlphanumeric = false;
                                                       options.Password.RequireDigit           = false;
                                                       options.Password.RequireLowercase       = false;
                                                       options.Password.RequireUppercase       = false;
                                                   }).AddEntityFrameworkStores<SLawDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<ILawyerWriteRepository, LawyerWriteRepository>();
            services.AddScoped<ILawyerReadRepository, LawyerReadRepository>();

            services.AddScoped<IPracticeAreaReadRepository, PracticeAreaReadRepository>();
            services.AddScoped<IPracticeAreaWriteRepository, PracticeAreaWriteRepository>();

            services.AddScoped<IContactFormWriteRepository, ContactFormWriteRepository>();
            services.AddScoped<IContactFormReadRepository, ContactFormReadRepository>();

            services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
            services.AddScoped<IAboutReadRepository, AboutReadRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
