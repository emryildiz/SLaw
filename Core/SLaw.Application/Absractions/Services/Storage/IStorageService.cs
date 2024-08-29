namespace SLaw.Application.Absractions.Services.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
