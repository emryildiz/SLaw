namespace SLaw.Application.Absractions.Services.Authentications
{
    public interface IAuthService : IInternalAuthentication
    {
        public Task PasswordResetAsync(string email);

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
