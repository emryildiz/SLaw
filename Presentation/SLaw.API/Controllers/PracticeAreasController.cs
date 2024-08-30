using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.PracticeAreas.Create;
using SLaw.Application.Features.Commands.PracticeAreas.Delete;
using SLaw.Application.Features.Commands.PracticeAreas.Update;
using SLaw.Application.Features.Queries.PracticeAreas.GetAll;
using System.Net;

namespace SLaw.API.Controllers
{
    public class PracticeAreasController : BaseController
    {
        private readonly IMediator _mediator;

        public PracticeAreasController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreatePracticeAreaCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.Created));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllPracticeAreaQueryResponse> response = await this._mediator.Send(new GetAllPracticeAreaQueryRequest());

            return this.CreateActionResult(CustomResponseSuccessDto<List<GetAllPracticeAreaQueryResponse>>.Create(HttpStatusCode.OK, response));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdatePracticeAreaCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeletePracticeAreaCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }
    }
}
