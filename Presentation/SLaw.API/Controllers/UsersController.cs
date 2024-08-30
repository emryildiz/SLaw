using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using System.Net;
using SLaw.Application.Features.Commands.Users.Create;

namespace SLaw.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }
    }
}
