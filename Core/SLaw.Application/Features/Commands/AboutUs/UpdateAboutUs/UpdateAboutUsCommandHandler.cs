using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories.About;

namespace SLaw.Application.Features.Commands.AboutUs.UpdateAboutUs
{
    public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommandRequest>
    {
        private readonly IAboutWriteRepository _aboutWriteRepository;
        private readonly IAboutReadRepository _aboutReadRepository;

        public UpdateAboutUsCommandHandler(IAboutWriteRepository aboutWriteRepository, IMapper mapper, IAboutReadRepository aboutReadRepository)
        {
            this._aboutWriteRepository = aboutWriteRepository;
            this._aboutReadRepository = aboutReadRepository;
        }

        public async Task Handle(UpdateAboutUsCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.AboutUs aboutUs = await this._aboutReadRepository.GetAll().FirstOrDefaultAsync(cancellationToken);

            if (aboutUs is null)
            {
                throw new Exception("Hakkımızda bilgisi bulunamadı");
            }

            aboutUs.Description = request.Description;

            await this._aboutWriteRepository.SaveChangesAsync();
        }
    }
}
