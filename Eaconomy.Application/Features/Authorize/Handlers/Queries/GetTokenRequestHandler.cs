using AutoMapper;
using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.Features.Authorize.Requests.Queries;

using Eaconomy.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Features.Authorize.Handlers.Queries
{
    public class GetTokenRequestHandler : IRequestHandler<GetTokenRequest, TokenResponse>
    {
        private readonly ITokenRepository tokenRepository;
        private readonly IMapper mapper;

        public GetTokenRequestHandler(ITokenRepository tokenRepository, IMapper mapper)
        {
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
        }

        public async Task<TokenResponse> Handle(GetTokenRequest request, CancellationToken cancellationToken)
        {
            var tokenRepsonse = await tokenRepository.GetToken(request.UserEmail, request.Password);
            //return mapper.Map<EmployeeDTO>(employee);
            return tokenRepsonse;
        }
    }
}
