using AutoMapper;
using Eaconomy.Application.DTO.Employee;
using Eaconomy.Application.Features.Employee.Requests.Queries;
using Eaconomy.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Employee.Handlers.Queries
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListRequest, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeeListHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var employees =  await employeeRepository.GetAll();
            return mapper.Map<List<EmployeeDTO>>(employees);
        }
    }
}
