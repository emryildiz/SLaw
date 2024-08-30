using MediatR;

namespace SLaw.Application.Features.Commands.ContactForms.Create
{
    public class CreateContactFormCommandRequest : IRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }
    }
}
