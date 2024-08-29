using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SLaw.Application.Absractions.Services.Storage.Local;

namespace SLaw.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(this._webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string pathOrCombineName)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileName = file.FileName; //TODO SEO ve isim düzgünlüğü için file rename işlemi yapılacak.

                await this.CopyAsync(Path.Combine(uploadPath, fileName), file);

                datas.Add((fileName, Path.Combine(path, fileName)));
            }

            return datas;
        }

        public void Delete(string pathOrContainerName, string fileName) => File.Delete(Path.Combine(pathOrContainerName, fileName));

        public void Delete(string filePath) => File.Delete(filePath);

        public List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo directoryInfo = new(pathOrContainerName);

            return directoryInfo.GetFiles().Select(x => x.Name).ToList();
        }

        public bool HasFile(string pathOrContainerName, string fileName) => File.Exists(Path.Combine(pathOrContainerName, fileName));

        public async Task<bool> CopyAsync(string path, IFormFile file)
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            await file.CopyToAsync(fileStream);

            await fileStream.FlushAsync();

            return true;
        }
    }
}
