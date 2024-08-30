using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SLaw.Application.Absractions.Services.Authentications;
using SLaw.Application.Absractions.Services.Mail;
using SLaw.Application.Absractions.Services.Tokens;
using SLaw.Application.Absractions.Services.Users;
using SLaw.Application.Dtos;
using SLaw.Application.Exceptions;
using SLaw.Domain.Entities.Identity;
using System.Text;

namespace SLaw.Persistence.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMailService _mailService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService, IMailService mailService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenHandler = tokenHandler;
            this._userService = userService;
            this._mailService = mailService;
        }

        public async Task<Token> LoginAsync(string email, string password, int accessTokenLifeTime)
        {
            AppUser user = await this._userManager.FindByEmailAsync(email);

            if (user is null) { throw new NotFoundUserException(); }

            SignInResult result = await this._signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded) //Authentication Başarılı
            {
                Token token = this._tokenHandler.CreateAccessToken(accessTokenLifeTime, user);

                await this._userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);

                return token;
            }

            throw new AuthenticationFailedException();
        }

        public async Task<Token> RefreshTokenAsync(string refreshToken)
        {
            AppUser user = await this._userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = this._tokenHandler.CreateAccessToken(15, user);
                await this._userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);

                return token;
            }

            throw new NotFoundUserException();
        }

        public async Task PasswordResetAsync(string email)
        {
            AppUser user = await this._userManager.FindByEmailAsync(email);

            if (user is null) { throw new NotFoundUserException(); }

            string resetToken = await this._userManager.GeneratePasswordResetTokenAsync(user);

            byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
            resetToken = WebEncoders.Base64UrlEncode(tokenBytes);

            await this._mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser user = await this._userManager.FindByIdAsync(userId);

            if (user != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);

                return await this._userManager.VerifyUserTokenAsync(user, this._userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }

            return false;
        }
    }
}
