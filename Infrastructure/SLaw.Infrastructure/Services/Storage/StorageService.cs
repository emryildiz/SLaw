using Microsoft.AspNetCore.Http;
using SLaw.Application.Absractions.Services.Storage;

namespace SLaw.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public string StorageName => this._storage.GetType().Name;

        public StorageService(IStorage storage)
        {
            this._storage = storage;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files) => await this._storage.UploadAsync(pathOrContainerName, files);

        public void Delete(string pathOrContainerName, string fileName) => this._storage.Delete(pathOrContainerName, fileName);

        public void Delete(string filePath) => this._storage.Delete(filePath);

        public List<string> GetFiles(string pathOrContainerName) => this._storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName) => this._storage.HasFile(pathOrContainerName, fileName);
    }
}
