namespace SLaw.Application.Exceptions
{
    public class PasswordChangeFailedException : Exception
    {
        public PasswordChangeFailedException() : base("Şifre değiştirme başarısız") { }
    }
}
