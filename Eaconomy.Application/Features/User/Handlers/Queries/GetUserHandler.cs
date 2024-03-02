using AutoMapper;
using Eaconomy.Application.DTO.Employee;
using Eaconomy.Application.DTO.User;
using Eaconomy.Application.Features.Employee.Requests.Queries;
using Eaconomy.Application.Features.User.Requests.Queries;
using Eaconomy.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.User.Handlers.Queries
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, UserDTO>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUser(request.UserEmail, request.Password);
           return mapper.Map<UserDTO>(user);
        }
    }
}
