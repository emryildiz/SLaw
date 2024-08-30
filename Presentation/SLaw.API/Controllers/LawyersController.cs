using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.Lawyers.Create;
using SLaw.Application.Features.Commands.Lawyers.Delete;
using SLaw.Application.Features.Commands.Lawyers.Update;
using SLaw.Application.Features.Queries.Lawyers.GetAll;
using System.Net;

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

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateLawyerCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeleteLawyerCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }
    }
}
