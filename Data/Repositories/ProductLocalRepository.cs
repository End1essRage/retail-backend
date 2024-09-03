using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public class ProductLocalRepository : IProductRepository
    {
        private readonly AppContext _context;

        public ProductLocalRepository(AppContext context)
        {
            _context = context;
        }
        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductById(int id)
        {
            var product = await GetProductById(id);
            if (product == null)
                throw new ArgumentException("Not Found");

            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var productEntity = await GetProductById(product.Id);
            if (productEntity == null)
                throw new ArgumentException("Not Found");

            productEntity = product;

            await _context.SaveChangesAsync();
        }
    }
}