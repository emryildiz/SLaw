using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.LoginUsers;

namespace SLaw.API.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto<LoginUserCommandResponse>.Create(HttpStatusCode.Accepted, response));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin()
        {
            //TODO RefreshTokenLogin
            return this.Ok();
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset()
        {
            //TODO Password reset
            return this.Ok();
        }

        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken()
        {
            //Todo Verify password reset
            return this.Ok();
        }
    }
}
