using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories.About;

namespace SLaw.Application.Features.Queries.AboutUs.GetAboutUs
{
    public class GetAboutUsQueryHandler : IRequestHandler<GetAboutUsQueryRequest, GetAboutUsQueryResponse>
    {
        private readonly IAboutReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAboutUsQueryHandler(IAboutReadRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<GetAboutUsQueryResponse> Handle(GetAboutUsQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.AboutUs aboutUs = await this._repository.GetAll().FirstOrDefaultAsync(cancellationToken);

            if (aboutUs is null)
            {
                throw new Exception("Hakkımızda bilgisi bulunamadı");
            }

            GetAboutUsQueryResponse response = this._mapper.Map<GetAboutUsQueryResponse>(aboutUs);

            return response;
        }
    }
}
