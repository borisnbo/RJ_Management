using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ksb.Api.Data;
using Ksb.Domain;
using Ksb.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ksb.EFReposiitory
{
    public class ChildrenRepository : IChildrenRepository
    {
        private KsbApiContext _context;
        public ChildrenRepository(KsbApiContext context)
        {
            _context = context;
        }
        public async Task<Children> AddAsync(Children item)
        {
            _context.Children.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(int Id)
        {
            var children = await _context.Children.FindAsync(Id);
            if (children == null)
            {
                throw new ApplicationException("Cet element n'existe pas");
            }

            _context.Children.Remove(children);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Children>> GetAllAsync()
        {
            return await _context.Children.ToListAsync();
        }

        public async Task<Children> GetByIdAsync(int Id)
        {
            var children = await _context.Children.FindAsync(Id);

            if (children == null)
            {
                throw new ApplicationException("Cet element n'existe pas");
            }

            return children;
        }

        public async Task<Children> UpdateAsync(Children item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }
    }
}
