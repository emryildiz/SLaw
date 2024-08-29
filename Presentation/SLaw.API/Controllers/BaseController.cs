using Microsoft.AspNetCore.Mvc;
using SLaw.Application.Dtos;

namespace SLaw.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if ((int)response.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = (int)response.StatusCode };
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }

        [NonAction]
        public IActionResult CreateActionResult(CustomResponseDto response)
        {
            if ((int)response.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = (int)response.StatusCode };
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }
    }
}
