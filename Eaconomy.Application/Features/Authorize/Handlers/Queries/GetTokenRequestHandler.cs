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
        //private readonly ITokenRepository tokenRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetTokenRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
           // this.tokenRepository = tokenRepository;
           _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<TokenResponse> Handle(GetTokenRequest request, CancellationToken cancellationToken)
        {
            var tokenRepsonse = await _unitOfWork.TokenRepository.GetToken(request.UserEmail, request.Password);
            //return mapper.Map<EmployeeDTO>(employee);
            return tokenRepsonse;
        }
    }
}
