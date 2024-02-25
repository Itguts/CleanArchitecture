using Eaconomy.Application.Repositories;
using Eaconomy.Domain.Entities;
using Eaconomy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Dapper;


namespace Eaconomy.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EaconomyDBContext eaconomyDBContext;
        private readonly EaconomyDBReadContext eaconomyDBReadContext;

        public EmployeeRepository(EaconomyDBContext eaconomyDBContext, EaconomyDBReadContext eaconomyDBReadContext)
        {
            this.eaconomyDBContext = eaconomyDBContext;
            this.eaconomyDBReadContext = eaconomyDBReadContext;
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

        //public async Task<Employee> GetById(int id)
        //{
        //    return await eaconomyDBContext.Employees.AsNoTracking().
        //        FirstOrDefaultAsync(emp => emp.Id==id);
        //}
        //using dapper
        public async Task<Employee> GetById(int id)
        {
            var sql = "SELECT * FROM Employees where id=@id";
            using (var connection = eaconomyDBReadContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Employee>(sql, new { id = id });
                return result;
            }
        }

        public async Task<Employee> Update(Employee entity)
        {
             eaconomyDBContext.Update(entity);
            await eaconomyDBContext.SaveChangesAsync();
            return entity;
        }
    }
}
