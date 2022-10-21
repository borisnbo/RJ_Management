using Ksb.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ksb.Repository
{
    public interface IChildrenRepository
    {
        Task<IEnumerable<Children>> GetAllAsync();
        Task<Children> GetByIdAsync(int Id);
        Task<Children> AddAsync(Children item);
        Task<Children> UpdateAsync(Children item);
        Task DeleteAsync(int Id);
    }
}
