using MediatR;

namespace SLaw.Application.Features.Commands.ContactForms.Delete
{
    public class DeleteContactFormCommandRequest : IRequest
    {
        public string Id { get; set; }
    }
}
