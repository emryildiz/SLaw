using MediatR;

namespace SLaw.Application.Features.Commands.LoginUsers
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
