using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int dd);
        Task<T> AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int Id);
    }
}
