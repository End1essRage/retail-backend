using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
        public Task<List<Product>> GetProductsByCategoryId(int categoryId);
        public Task<Product> GetProductById(int id);
        public Task CreateProduct(Product product);
        public Task UpdateProduct(Product product);
        public Task DeleteProductById(int id);
    }
}