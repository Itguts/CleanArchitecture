using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Common.Responses
{
    public enum ResponseType
    {
        Ok,
        NotFound,
        BadRequest,
        Forbidden,
        InternalServerError
    }
}
