using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SLaw.Application.Absractions.Services.Storage;
using SLaw.Application.Constants;
using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Commands.PracticeAreas.Create
{
    public class CreatePracticeAreaCommandHandler : IRequestHandler<CreatePracticeAreaCommandRequest>
    {
        private readonly IPracticeAreaWriteRepository _repository;
        private readonly IStorage _storageService;
        private readonly IMapper _mapper;

        public CreatePracticeAreaCommandHandler(IPracticeAreaWriteRepository repository, IStorage storageService, IMapper mapper)
        {
            this._repository = repository;
            this._storageService = storageService;
            this._mapper = mapper;
        }

        public async Task Handle(CreatePracticeAreaCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> paths = await this._storageService.UploadAsync(FilePaths.PracticeArea, new FormFileCollection() { request.Image });
            (string fileName, string pathOrContainerName) path = paths.First();

            PracticeArea practiceArea = this._mapper.Map<PracticeArea>(request);
            practiceArea.ImagePath = Path.Combine(path.pathOrContainerName, path.fileName);

            await this._repository.AddAsync(practiceArea);
            await this._repository.SaveChangesAsync();
        }
    }
}
