using MediatR;

namespace SLaw.Application.Features.Commands.Lawyers.Delete
{
    public class DeleteLawyerCommandRequest : IRequest
    {
        public string Id { get; set; }
    }
}
