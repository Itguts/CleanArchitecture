using Eaconomy.Application.Repositories;
using Eaconomy.Infrastructure.Data;
using Eaconomy.Infrastructure.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EaconomyDBContext _context;
        private readonly EaconomyDBReadContext _contextDBRead;
       // private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<JwtSettings> _jwtOptions;
        public UnitOfWork(EaconomyDBContext context, 
            EaconomyDBReadContext contextDBRead,
            //IHttpContextAccessor httpContextAccessor,
            IOptions<JwtSettings> jwtOptions)
        {
            _context = context;
            _contextDBRead = contextDBRead;
          //  this._httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptions;

        }

        private IEmployeeRepository _employeeRepository;

        private IUserRepository _userRepository;

        private ITokenRepository _tokenRepository;

       // private IRoleRepository _roleRepository;

        public IEmployeeRepository EmployeeRepository =>
           _employeeRepository ??= new EmployeeRepository(_context, _contextDBRead);
        public IUserRepository UserRepository =>
          _userRepository ??= new UsersRepository(_context);

        public ITokenRepository TokenRepository =>
         _tokenRepository ??= new TokenRepository(_context, _jwtOptions);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
