using Eaconomy.Application.Repositories;
using Eaconomy.Domain.Entities.Identity;
using Eaconomy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Infrastructure.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly EaconomyDBContext eaconomyDBContext;

        public RoleRepository(EaconomyDBContext eaconomyDBContext)
        {
            this.eaconomyDBContext = eaconomyDBContext;
        }

        public async Task<Roles> CreateRole(Roles role)
        {
            await eaconomyDBContext.Roles.AddAsync(role);
            return role;
        }
    }
}

