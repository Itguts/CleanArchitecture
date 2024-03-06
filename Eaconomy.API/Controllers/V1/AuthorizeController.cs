using Asp.Versioning;
using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.User;
using Eaconomy.Application.Features.Authorize.Requests.Queries;
using Eaconomy.Application.Features.Employee.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Eaconomy.API.Controllers.V1
{

    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizeController : ProjectBaseController
    {
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] ValidateUserDTO userCred)
        {
            throw new Exception("Explicit Error");
            var tokenResponse = await Mediatr.Send(new GetTokenRequest() { UserEmail = userCred.Email, Password = userCred.Password });
            if (tokenResponse == null)
            {
                return Unauthorized();
            }
            return Ok(tokenResponse);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenResponse tokenRequest)
        {
            var tokenResponse = await Mediatr.Send(new GetRefreshTokenRequest() { Token = tokenRequest.JWTToken, RefreshToken = tokenRequest.RefreshToken });
            if (tokenResponse == null)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}
