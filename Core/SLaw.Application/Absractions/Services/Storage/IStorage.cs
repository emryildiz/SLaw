using Microsoft.AspNetCore.Http;

namespace SLaw.Application.Absractions.Services.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        void Delete(string pathOrContainerName, string fileName);

        void Delete(string filePath);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    }
}
