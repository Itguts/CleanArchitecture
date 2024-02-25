using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Domain.Entities
{
    public class Employee
    {
        public int Id   { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public double Salary { get; set; }
    }
}
