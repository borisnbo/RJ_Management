using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ksb.Domain;
using Ksb.EFReposiitory;
using Ksb.Repository;

namespace Ksb.BusinessObject.logic
{
    public class ChildrenBO:IChildrenBO
    {
        private IChildrenRepository _repos;

        public ChildrenBO(IChildrenRepository repo)
        {
            _repos = repo;
        }

        public async Task<Children> AddAsync(Children item)
        {
            return await _repos.AddAsync(item);
        }

        public async Task DeleteAsync(int Id)
        {
            await _repos.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Children>> GetAllAsync()
        {
            return await _repos.GetAllAsync();
        }

        public async Task<Children> GetByIdAsync(int Id)
        {
            return await _repos.GetByIdAsync(Id);
        }

        public async Task<Children> UpdateAsync(Children item)
        {
            return await _repos.UpdateAsync(item);
        }
    }
}
