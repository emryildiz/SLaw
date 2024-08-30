using MediatR;

namespace SLaw.Application.Features.Queries.ContactForms.GetAll
{
    public class GetAllContactFormQueryRequest : IRequest<List<GetAllContactFormQueryResponse>> { }
}
