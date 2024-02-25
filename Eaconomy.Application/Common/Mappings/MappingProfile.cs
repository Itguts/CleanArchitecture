using AutoMapper;
using Eaconomy.Application.DTO.Employee;
using Eaconomy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Employee>();
        }
    }
}
