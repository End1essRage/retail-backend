using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;

namespace retail_backend.Data.Repositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        public Task<int> GetCategoryIdByName(string name);
    }
}