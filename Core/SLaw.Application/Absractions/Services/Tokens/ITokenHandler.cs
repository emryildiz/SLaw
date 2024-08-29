using SLaw.Application.Dtos;
using SLaw.Domain.Entities.Identity;

namespace SLaw.Application.Absractions.Services.Tokens
{
    public interface ITokenHandler
    {
        public Token CreateAccessToken(int second, AppUser user);

        public string CreateRefreshToken();
    }
}
