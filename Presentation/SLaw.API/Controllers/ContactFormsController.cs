using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;
using SLaw.Application.Features.Commands.ContactForms.Create;
using SLaw.Application.Features.Commands.ContactForms.Delete;
using SLaw.Application.Features.Queries.ContactForms.GetAll;

namespace SLaw.API.Controllers
{
    public class ContactFormsController : BaseController
    {
        private readonly IMediator _mediator;

        public ContactFormsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateContactFormCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.Created));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllContactFormQueryResponse> response = await this._mediator.Send(new GetAllContactFormQueryRequest());

            return this.CreateActionResult(CustomResponseSuccessDto<List<GetAllContactFormQueryResponse>>.Create(HttpStatusCode.OK, response));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeleteContactFormCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.CreateActionResult(CustomResponseSuccessDto.Create(HttpStatusCode.OK));
        }
    }
}
