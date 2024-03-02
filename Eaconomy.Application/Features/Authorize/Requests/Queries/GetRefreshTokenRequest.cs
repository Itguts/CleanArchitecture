using Eaconomy.Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Authorize.Requests.Queries
{
    public class GetRefreshTokenRequest : IRequest<TokenResponse>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
