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
    public class GetRefreshTokenRequestHandler : IRequestHandler<GetRefreshTokenRequest, TokenResponse>
    {
        // private readonly ITokenRepository tokenRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetRefreshTokenRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //this.tokenRepository = tokenRepository;
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<TokenResponse> Handle(GetRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var tokenRepsonse = await _unitOfWork.TokenRepository.GetRefreshToken(request.Token, request.RefreshToken);
            //return mapper.Map<EmployeeDTO>(employee);
            return tokenRepsonse;
        }

    }
}
