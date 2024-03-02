using Eaconomy.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Repositories
{
    public interface IUserRepository
    {
        Task<Users> CreateUser(Users user);

        Task<Users> GetUser(string email, string password);
    }
}
