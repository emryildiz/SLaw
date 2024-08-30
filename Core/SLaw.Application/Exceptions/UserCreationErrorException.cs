namespace SLaw.Application.Exceptions
{
    public class UserCreationErrorException : Exception
    {
        public UserCreationErrorException() : base("Kullanıcı oluşturma hatası") { }
    }
}
