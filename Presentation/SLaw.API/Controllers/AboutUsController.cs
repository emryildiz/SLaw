using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.AboutUs.UpdateAboutUs;
using System.Net;
using SLaw.Application.Features.Queries.AboutUs.GetAboutUs;

namespace SLaw.API.Controllers
{
    public class AboutUsController : BaseController
    {
        private readonly IMediator _mediator;

        public AboutUsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateAboutUsCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            GetAboutUsQueryResponse response = await this._mediator.Send(new GetAboutUsQueryRequest());

            return this.CreateActionResult(CustomResponseSuccessDto<GetAboutUsQueryResponse>.Create(HttpStatusCode.OK, response));
        }
    }
}
