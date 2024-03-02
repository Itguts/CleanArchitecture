using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.Employee;
using Eaconomy.Application.DTO.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.User.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDTO CreateUserDTO { get; set; }
    }
}
