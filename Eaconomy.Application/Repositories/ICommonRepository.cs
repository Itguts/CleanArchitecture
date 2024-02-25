using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Application.Repositories
{
    public interface ICommonRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Update (T entity);

        Task<T> Create (T entity);
        Task<bool> Delete(int id);
    }
}
