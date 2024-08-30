namespace SLaw.Application.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException() : base("Kullanıcı bulunamadı") { }
    }
}
