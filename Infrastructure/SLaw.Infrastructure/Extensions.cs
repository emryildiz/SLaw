using Microsoft.Extensions.DependencyInjection;
using SLaw.Application.Absractions.Services.Mail;
using SLaw.Application.Absractions.Services.Storage;
using SLaw.Application.Absractions.Services.Tokens;
using SLaw.Infrastructure.Services.Mail;
using TokenHandler = SLaw.Infrastructure.Services.Tokens.TokenHandler;

namespace SLaw.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IMailService, MailService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
