using Eaconomy.Application.Repositories;
using Eaconomy.Domain.Entities.Identity;
using Eaconomy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Infrastructure.Repository
{
    public class UsersRepository : IUserRepository
    {
        private readonly EaconomyDBContext eaconomyDBContext;

        public UsersRepository(EaconomyDBContext eaconomyDBContext)
        {
            this.eaconomyDBContext = eaconomyDBContext;
        }

        public async Task<Users> CreateUser(Users user)
        {
             await eaconomyDBContext.Users.AddAsync(user);
            return user;
        }
        public async Task<Users> GetUser(string email, string password)
        {
            return await eaconomyDBContext.Users.FirstOrDefaultAsync(user => user.Email==email && user.Password==password);
           
        }

       
    }
}
