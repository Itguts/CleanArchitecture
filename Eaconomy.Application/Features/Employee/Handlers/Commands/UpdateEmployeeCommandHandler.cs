using AutoMapper;
using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.Employee.Validators;
using Eaconomy.Application.Features.Employee.Requests.Commands;
using Eaconomy.Application.Repositories;
using MediatR;

namespace Eaconomy.Application.Features.Employee.Handlers.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseCommandResponse>
    {
        //  private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            // _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<BaseCommandResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateEmployeeValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Employee failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var employee = _mapper.Map<Domain.Entities.Employee>(request.EmployeeDTO);
                await _unitOfWork.EmployeeRepository.Update(employee);
                response.Message = "Employee updated successfully";
                response.Id = (int)employee.Id;
                response.Success = true;
            }
            return response;
        }
    }
}