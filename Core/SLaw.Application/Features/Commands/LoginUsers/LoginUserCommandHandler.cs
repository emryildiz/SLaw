using MediatR;
using SLaw.Application.Absractions.Services.Authentications;
using SLaw.Application.Dtos;

namespace SLaw.Application.Features.Commands.LoginUsers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            this._authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await this._authService.LoginAsync(request.Email, request.Password, 900);

            return new LoginUserCommandResponse
            {
                Token = token
            };
        }
    }
}
