using AutoMapper;
using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.Employee.Validators;
using Eaconomy.Application.Features.Employee.Requests.Commands;
using Eaconomy.Application.Repositories;
using MediatR;


namespace Eaconomy.Application.Features.Employee.Handlers.Commands
{
    partial class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse>
    {
        // private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            // this.employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

      

        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmployeeValidator();
            var validationResult = await validator.ValidateAsync(request.CreateEmployeeDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create Employee failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var employee = mapper.Map<Domain.Entities.Employee>(request.CreateEmployeeDTO);
                await _unitOfWork.EmployeeRepository.Create(employee);
                response.Message = "Employee created successfully";
                response.Id = (int)employee.Id;
                response.Success = true;
            }
            return response;
        }
    }
}
