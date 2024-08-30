using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLaw.Application.Repositories.ContactForms;
using SLaw.Domain.Entities;

namespace SLaw.Application.Features.Queries.ContactForms.GetAll
{
    public class GetAllContactFormQueryHandler : IRequestHandler<GetAllContactFormQueryRequest, List<GetAllContactFormQueryResponse>>
    {
        private readonly IContactFormReadRepository _contactFormReadRepository;
        private readonly IMapper _mapper;

        public GetAllContactFormQueryHandler(IContactFormReadRepository contactFormReadRepository, IMapper mapper)
        {
            this._contactFormReadRepository = contactFormReadRepository;
            this._mapper = mapper;
        }

        public async Task<List<GetAllContactFormQueryResponse>> Handle(GetAllContactFormQueryRequest request, CancellationToken cancellationToken)
        {
            List<ContactForm> contactForms = await this._contactFormReadRepository.GetAll(false)
                                                       .OrderByDescending(c => c.CreatedDate)
                                                       .ToListAsync(cancellationToken: cancellationToken);

            List<GetAllContactFormQueryResponse> response = this._mapper.Map<List<GetAllContactFormQueryResponse>>(contactForms);

            return response;
        }
    }
}
