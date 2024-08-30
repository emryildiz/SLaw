using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Queries.PracticeAreas.GetAll
{
    public class GetAllPracticeAreaQueryHandler : IRequestHandler<GetAllPracticeAreaQueryRequest, List<GetAllPracticeAreaQueryResponse>>
    {
        private readonly IPracticeAreaReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPracticeAreaQueryHandler(IPracticeAreaReadRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<GetAllPracticeAreaQueryResponse>> Handle(GetAllPracticeAreaQueryRequest request, CancellationToken cancellationToken)
        {
            List<PracticeArea> practiceAreas = await this._repository.GetAll(false).ToListAsync(cancellationToken: cancellationToken);

            List<GetAllPracticeAreaQueryResponse> response = this._mapper.Map<List<GetAllPracticeAreaQueryResponse>>(practiceAreas);

            return response;
        }
    }
}
