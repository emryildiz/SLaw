using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SLaw.Application.Absractions.Services.Authentications;
using SLaw.Application.Absractions.Services.Tokens;
using SLaw.Application.Absractions.Services.Users;
using SLaw.Application.Dtos;
using SLaw.Domain.Entities.Identity;

namespace SLaw.Persistence.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenHandler = tokenHandler;
            this._userService = userService;
        }

        public async Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime)
        {
            AppUser user = await this._userManager.FindByEmailAsync(email);

            if (user is null) { throw new Exception(); } // TODO : Exception

            SignInResult result = await this._signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded) //Authentication Başarılı
            {
                Token token = this._tokenHandler.CreateAccessToken(accessTokenLifeTime, user);

                //TODO :await this.RefreshTokenAsync(token.RefreshToken, )

                return token;
            }

            throw new Exception(); // TODO : Exception
        }

        public Task<Token> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task PasswordResetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
