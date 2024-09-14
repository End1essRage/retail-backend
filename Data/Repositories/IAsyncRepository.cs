using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<int> SaveChangesAsync();
    }
}