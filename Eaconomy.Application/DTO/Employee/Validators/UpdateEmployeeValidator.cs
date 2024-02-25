using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.DTO.Employee.Validators
{
    public class UpdateEmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}