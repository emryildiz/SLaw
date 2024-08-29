using SLaw.Application.Dtos;

namespace SLaw.Application.Absractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        public Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime);

        public Task<Token> RefreshTokenAsync(string refreshToken);
    }
}
