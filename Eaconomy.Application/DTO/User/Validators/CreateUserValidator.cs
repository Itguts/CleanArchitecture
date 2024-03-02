using Eaconomy.Application.DTO.Employee;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.DTO.User.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.Email).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.Password).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.Password).NotNull().MinimumLength(8).WithMessage("{PropertyName} must be present");
            RuleFor(p => p.Role).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.Email).EmailAddress().WithMessage("{PropertyName} is not a email type");
        }
    }
}