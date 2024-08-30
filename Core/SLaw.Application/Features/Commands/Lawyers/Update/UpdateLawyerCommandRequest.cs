using MediatR;

namespace SLaw.Application.Features.Commands.Lawyers.Update
{
    public class UpdateLawyerCommandRequest : IRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Title { get; set; }

        public string CellPhone { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
