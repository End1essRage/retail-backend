using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<int> GetCategoryIdByName(string name);
        public Task CreateCategory(Category category);
        public Task UpdateCategory(Category category);
        public Task DeleteCategoryById(int id);
    }
}