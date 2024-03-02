using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Authorize.Requests.Queries
{
    public class GetTokenRequest : IRequest<TokenResponse>
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
