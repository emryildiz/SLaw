using AutoMapper;
using MediatR;
using SLaw.Application.Repositories.Lawyers;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Commands.Lawyers.Create
{
    public class CreateLawyerCommandHandler : IRequestHandler<CreateLawyerCommandRequest>
    {
        private readonly ILawyerWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public CreateLawyerCommandHandler(ILawyerWriteRepository writeRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._mapper = mapper;
        }

        public async Task Handle(CreateLawyerCommandRequest request, CancellationToken cancellationToken)
        {
            Lawyer lawyer = this._mapper.Map<Lawyer>(request);

            await this._writeRepository.AddAsync(lawyer);
            await this._writeRepository.SaveChangesAsync();
        }
    }
}
