using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Employee.Requests.Commands
{
    public class UpdateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public EmployeeDTO EmployeeDTO { get; }
    }
}
