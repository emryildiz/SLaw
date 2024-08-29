using MediatR;

namespace SLaw.Application.Features.Queries.Lawyers.GetAll
{
    public class GetAllLawyersQueryRequest : IRequest<List<GetAllLawyersQueryResponse>> { }
}
