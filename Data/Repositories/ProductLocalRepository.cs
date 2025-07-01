using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public class ProductLocalRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppContext _context;

        public ProductLocalRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByIds(List<int> ids)
        {
            return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        }
    }
}