using Microsoft.Extensions.DependencyInjection;
using SLaw.Application.Absractions.Services.Storage;
using SLaw.Application.Absractions.Services.Tokens;
using TokenHandler = SLaw.Infrastructure.Services.Tokens.TokenHandler;

namespace SLaw.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            //TODO
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
