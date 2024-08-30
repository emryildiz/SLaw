using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SLaw.Application.Absractions.Services.Storage;
using SLaw.Application.Constants;
using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Commands.PracticeAreas.Update
{
    public class UpdatePracticeAreaCommandHandler : IRequestHandler<UpdatePracticeAreaCommandRequest>
    {
        private readonly IPracticeAreaWriteRepository _writeRepository;
        private readonly IPracticeAreaReadRepository _readRepository;
        private readonly IStorage _storageService;

        public UpdatePracticeAreaCommandHandler(IPracticeAreaReadRepository readRepository, IPracticeAreaWriteRepository writeRepository, IStorage storageService)
        {
            this._readRepository = readRepository;
            this._writeRepository = writeRepository;
            this._storageService = storageService;
        }

        public async Task Handle(UpdatePracticeAreaCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> paths = await this._storageService.UploadAsync(FilePaths.PracticeArea, new FormFileCollection() { request.Image });
            (string fileName, string pathOrContainerName) path = paths.First();

            PracticeArea practiceArea = await this._readRepository.GetByIdAsync(request.Id);
            practiceArea.Name = request.Name;
            practiceArea.Description = request.Description;
            practiceArea.ImagePath = Path.Combine(path.pathOrContainerName, path.fileName);

            await this._writeRepository.SaveChangesAsync();
        }
    }
}
