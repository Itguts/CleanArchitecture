using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.DTO.Employee
{
    public class CreateEmployeeDTO
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public double Salary { get; set; }
    }
}
