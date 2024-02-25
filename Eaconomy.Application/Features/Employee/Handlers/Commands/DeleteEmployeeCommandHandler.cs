using AutoMapper;
using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.Features.Employee.Requests.Commands;
using Eaconomy.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Employee.Handlers.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepository EmployeeRepository;
        private readonly IMapper Mapper;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.Mapper = mapper;
            this.EmployeeRepository = employeeRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            await EmployeeRepository.Delete(request.EmployeeId);
            response.Message = "Employee deleted successfully";
            response.Id = (int)request.EmployeeId;
            response.Success = true;
            return response;
        }
    }
}