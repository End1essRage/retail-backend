using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public class CategoryLocalRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppContext _context;

        public CategoryLocalRepository(AppContext context) : base(context)
        {
            _context = context;
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
    }
}