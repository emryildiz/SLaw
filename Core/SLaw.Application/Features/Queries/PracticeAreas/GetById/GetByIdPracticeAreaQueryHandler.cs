using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SLaw.Application.Repositories.PraticeAreas;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Queries.PracticeAreas.GetById
{
    public class GetByIdPracticeAreaQueryHandler : IRequestHandler<GetByIdPracticeAreaQueryRequest, GetByIdPracticeAreaQueryResponse>
    {
        private readonly IPracticeAreaReadRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdPracticeAreaQueryHandler(IPracticeAreaReadRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<GetByIdPracticeAreaQueryResponse> Handle(GetByIdPracticeAreaQueryRequest request, CancellationToken cancellationToken)
        {
            PracticeArea practiceArea = await this._repository.GetByIdAsync(request.Id, false);

            GetByIdPracticeAreaQueryResponse response = this._mapper.Map<GetByIdPracticeAreaQueryResponse>(practiceArea);

            return response;
        }
    }
}
