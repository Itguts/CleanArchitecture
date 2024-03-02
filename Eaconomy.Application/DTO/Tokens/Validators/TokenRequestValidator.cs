using Eaconomy.Application.DTO.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.DTO.Tokens.Validators
{
    public class TokenRequestValidator : AbstractValidator<TokenRequest>
    {
        public TokenRequestValidator() {
            RuleFor(p => p.JWTToken).NotNull().WithMessage("{PropertyName} must be present");
            RuleFor(p => p.RefreshToken).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
