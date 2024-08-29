using MediatR;

namespace SLaw.Application.Features.Commands.Lawyers.Create
{
    public class CreateLawyerCommandRequest : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }

        public string CellPhone { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
