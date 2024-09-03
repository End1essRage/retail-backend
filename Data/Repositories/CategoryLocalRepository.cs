using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public class CategoryLocalRepository : ICategoryRepository
    {
        private readonly AppContext _context;

        public CategoryLocalRepository(AppContext context)
        {
            _context = context;
        }

        public async Task CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryById(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null)
                throw new ArgumentException("Not Found");

            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> GetCategoryIdByName(string name)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Name == name);
            if (category == null)
            {
                throw new ArgumentException("Not Found");
            }

            return category.Id;
        }

        public async Task UpdateCategory(Category category)
        {
            var categoryEntity = await GetCategoryById(category.Id);
            if (categoryEntity == null)
                throw new ArgumentException("Not Found");

            categoryEntity = category;

            await _context.SaveChangesAsync();
        }
    }
}