using Eaconomy.Application.Common.Responses;
using Eaconomy.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Repositories
{
    public interface ITokenRepository
    {
        Task<TokenResponse> GetToken(string userEmail, string password);
        Task<TokenResponse> GetRefreshToken(string token, string refreshToken);

    }
}
