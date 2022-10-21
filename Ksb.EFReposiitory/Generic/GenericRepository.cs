using Ksb.Api.Data;
using Ksb.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ksb.EFReposiitory.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private KsbApiContext _context;
        private DbSet<T> dbSet;
        public GenericRepository(KsbApiContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async virtual Task<T> AddAsync(T item)
        {
            dbSet.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async virtual Task DeleteAsync(int Id)
        {
            var T = await dbSet.FindAsync(Id);
            if (T == null)
            {
                throw new ApplicationException("Cet element n'existe pas");
            }

            dbSet.Remove(T);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async virtual Task<T> GetByIdAsync(int Id)
        {
            var T = await dbSet.FindAsync(Id);

            if (T == null)
            {
                throw new ApplicationException("Cet element n'existe pas");
            }

            return T;
        }

        public async virtual Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }
    }
}
