using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.DTO.Tokens
{
    public class TokenRequest
    {
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
