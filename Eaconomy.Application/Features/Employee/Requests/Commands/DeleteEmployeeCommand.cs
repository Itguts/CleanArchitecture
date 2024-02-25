using Eaconomy.Application.Common.Responses;
using MediatR;


namespace Eaconomy.Application.Features.Employee.Requests.Commands
{
    public class DeleteEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public int EmployeeId { get; set; }
    }
}
