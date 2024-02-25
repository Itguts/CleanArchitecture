using FluentValidation;

namespace Eaconomy.Application.DTO.Employee.Validators
{
    public class CreateEmployeeValidator:AbstractValidator<CreateEmployeeDTO>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
