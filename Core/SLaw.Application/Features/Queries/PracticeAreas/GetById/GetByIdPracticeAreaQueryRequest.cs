using MediatR;

namespace SLaw.Application.Features.Queries.PracticeAreas.GetById
{
    public class GetByIdPracticeAreaQueryRequest : IRequest<GetByIdPracticeAreaQueryResponse>
    {
        public string Id { get; set; }
    }
}
