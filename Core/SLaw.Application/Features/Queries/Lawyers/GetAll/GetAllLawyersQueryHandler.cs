using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories.Lawyers;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Queries.Lawyers.GetAll
{
    public class GetAllLawyersQueryHandler : IRequestHandler<GetAllLawyersQueryRequest, List<GetAllLawyersQueryResponse>>
    {
        private readonly ILawyerReadRepository _readRepository;
        private readonly IMapper _mapper;

        public GetAllLawyersQueryHandler(ILawyerReadRepository readRepository, IMapper mapper)
        {
            this._readRepository = readRepository;
            this._mapper = mapper;
        }

        public async Task<List<GetAllLawyersQueryResponse>> Handle(GetAllLawyersQueryRequest request, CancellationToken cancellationToken)
        {
            List<Lawyer> lawyers = await this._readRepository.GetAll(false).ToListAsync(cancellationToken: cancellationToken);

            return this._mapper.Map<List<GetAllLawyersQueryResponse>>(lawyers);
        }
    }
}
