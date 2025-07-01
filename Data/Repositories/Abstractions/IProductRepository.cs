using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        public Task<List<Product>> GetProductsByCategoryId(int categoryId);
        public Task<List<Product>> GetProductsByIds(List<int> ids);
    }
}