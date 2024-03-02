using Eaconomy.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Repositories
{
    public interface IRoleRepository
    {
        Task<Roles> CreateRole(Roles role);
    }
}
