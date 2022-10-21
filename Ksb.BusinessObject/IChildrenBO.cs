using Ksb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksb.BusinessObject
{
    public interface IChildrenBO
    {
        Task<IEnumerable<Children>> GetAllAsync();
        Task<Children> GetByIdAsync(int Id);
        Task<Children> AddAsync(Children item);
        Task<Children> UpdateAsync(Children item);
        Task DeleteAsync(int Id);
    }
}
