using Eaconomy.Application.DTO.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeeRequest : IRequest<EmployeeDTO>
    {
        public int EmployeeId { get; }
    }
}
