using AutoMapper;
using Eaconomy.Application.DTO.Employee;
using Eaconomy.Application.Features.Employee.Requests.Queries;
using Eaconomy.Application.Repositories;
using MediatR;


namespace Eaconomy.Application.Features.Employee.Handlers.Queries
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeRequest, EmployeeDTO>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetById(request.EmployeeId);
            return mapper.Map<EmployeeDTO>(employee);
        }
    }
}
