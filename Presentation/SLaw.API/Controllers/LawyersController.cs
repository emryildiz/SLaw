using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.Lawyers.Create;
using SLaw.Application.Features.Queries.Lawyers.GetAll;

namespace SLaw.API.Controllers
{
    public class LawyersController : BaseController
    {
        private readonly IMediator _mediator;

        public LawyersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateLawyerCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllLawyersQueryResponse> response = await this._mediator.Send(new GetAllLawyersQueryRequest());

            return this.CreateActionResult(CustomResponseSuccessDto<List<GetAllLawyersQueryResponse>>.Create(HttpStatusCode.OK, response));
        }
    }
}
