using MediatR;

namespace SLaw.Application.Features.Commands.PracticeAreas.Delete
{
    public class DeletePracticeAreaCommandRequest : IRequest
    {
        public string Id { get; set; }
    }
}
