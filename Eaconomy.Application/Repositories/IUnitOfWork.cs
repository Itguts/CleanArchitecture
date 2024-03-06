using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IUserRepository UserRepository { get; }
        ITokenRepository TokenRepository { get; }
       // IRoleRepository RoleRepository { get; }
    }
}
