using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.Employee;
using MediatR;


namespace Eaconomy.Application.Features.Employee.Requests.Commands
{
    public class CreateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public CreateEmployeeDTO CreateEmployeeDTO { get; set; }
    }
}
