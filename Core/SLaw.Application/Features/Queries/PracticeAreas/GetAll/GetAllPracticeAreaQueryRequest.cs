using MediatR;

namespace SLaw.Application.Features.Queries.PracticeAreas.GetAll
{
    public class GetAllPracticeAreaQueryRequest : IRequest<List<GetAllPracticeAreaQueryResponse>> { }
}
