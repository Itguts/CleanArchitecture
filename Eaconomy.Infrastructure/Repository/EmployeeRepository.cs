using Eaconomy.Application.Repositories;
using Eaconomy.Domain.Entities;
using Eaconomy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EaconomyDBContext eaconomyDBContext;

        public EmployeeRepository(EaconomyDBContext eaconomyDBContext)
        {
            this.eaconomyDBContext = eaconomyDBContext;
        }

        public async Task<Employee> Create(Employee entity)
        {
            await eaconomyDBContext.Employees.AddAsync(entity);
            await eaconomyDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            return await eaconomyDBContext.Employees.Where(emp => emp.Id == id).ExecuteDeleteAsync()==1 ? true : false;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await eaconomyDBContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await eaconomyDBContext.Employees.AsNoTracking().
                FirstOrDefaultAsync(emp => emp.Id==id);
        }

        public async Task<Employee> Update(Employee entity)
        {
             eaconomyDBContext.Update(entity);
            await eaconomyDBContext.SaveChangesAsync();
            return entity;
        }
    }
}
