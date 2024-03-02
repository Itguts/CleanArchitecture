using AutoMapper;
using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.DTO.Employee.Validators;
using Eaconomy.Application.DTO.User.Validators;
using Eaconomy.Application.Features.User.Requests.Commands;
using Eaconomy.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public CreateUserCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }



        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request.CreateUserDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create User failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var user = mapper.Map<Domain.Entities.Identity.Users>(request.CreateUserDTO);
                await userRepository.CreateUser(user);
                response.Message = "User created successfully";
                response.Id = (int)user.Id;
                response.Success = true;
            }
            return response;
        }
    }
}