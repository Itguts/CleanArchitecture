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
        //private readonly IEmployeeRepository EmployeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper Mapper;
        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.Mapper = mapper;
            //  this.EmployeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            await _unitOfWork.EmployeeRepository.Delete(request.EmployeeId);
            response.Message = "Employee deleted successfully";
            response.Id = (int)request.EmployeeId;
            response.Success = true;
            return response;
        }
    }
}