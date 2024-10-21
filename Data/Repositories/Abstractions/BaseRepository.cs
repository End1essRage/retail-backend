using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly AppContext _context;
        public BaseRepository(AppContext context)
        {
            _context = context;
        }

        public int Create(T entity)
        {
            var item = _context.Set<T>().Add(entity);
            return item.Entity.Id;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}