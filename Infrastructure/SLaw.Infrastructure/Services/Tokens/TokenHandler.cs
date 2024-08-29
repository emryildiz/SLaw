using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SLaw.Application.Absractions.Services.Tokens;
using SLaw.Domain.Entities.Identity;

namespace SLaw.Infrastructure.Services.Tokens
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public Application.Dtos.Token CreateAccessToken(int second, AppUser user)
        {
            Application.Dtos.Token token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(this._configuration["Token:SecurityKey"] ?? string.Empty));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddSeconds(second);

            if (user?.UserName is null) { throw new Exception(); }

            JwtSecurityToken securityToken = new(audience: this._configuration["Token:Auidence"],
                                                 issuer: this._configuration["Token:Issuer"],
                                                 expires: token.Expiration,
                                                 notBefore: DateTime.UtcNow,
                                                 signingCredentials: signingCredentials,
                                                 claims: new List<Claim>
                                                 {
                                                     new(ClaimTypes.Name, user.UserName)
                                                 });

            JwtSecurityTokenHandler tokenHandler = new();

            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = this.CreateRefreshToken();

            token.Username = user.UserName;

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];

            using RandomNumberGenerator random = RandomNumberGenerator.Create();

            random.GetBytes(number);

            return Convert.ToBase64String(number);
        }
    }
}
