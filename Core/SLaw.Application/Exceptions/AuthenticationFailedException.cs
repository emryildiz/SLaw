namespace SLaw.Application.Exceptions
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException() : base("Kimlik doğrulama başarısız") { }
    }
}
