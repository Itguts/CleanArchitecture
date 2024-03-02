using Eaconomy.Application.DTO.Employee;
using Eaconomy.Application.DTO.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.User.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDTO>
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
