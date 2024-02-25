using Eaconomy.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eaconomy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProjectBaseController : ControllerBase
    {
        private ISender _mediatr;

        protected ISender Mediatr => _mediatr ??  HttpContext.RequestServices.GetRequiredService<ISender>();
        protected IActionResult SwitchResponse(ResponseType responseType)
        {
            return responseType switch
            {
                ResponseType.Ok => Ok(),
                ResponseType.NotFound => NotFound(),
                ResponseType.Forbidden => StatusCode(403),
                ResponseType.InternalServerError => StatusCode(500),
                _ => BadRequest(base.ModelState),
            };
        }

        protected IActionResult SwitchResponse<T>(ResponseType responseType, T responseModel) where T : class
        {
            if (responseType == ResponseType.Ok)
            {
                return Ok(responseModel);
            }
            return SwitchResponse(responseType);
        }
    }
}