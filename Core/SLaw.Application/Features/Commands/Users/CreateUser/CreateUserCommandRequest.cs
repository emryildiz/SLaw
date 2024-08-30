using MediatR;

namespace SLaw.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandRequest : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
