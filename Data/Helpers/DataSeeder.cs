using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;
using retail_backend.Data.Repositories;

namespace retail_backend.Data.Helpers
{
    public static class DataSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var categories = new List<Category>
            {
                new Category(){Name = "Напитки"},
                new Category(){Name = "Булочки"},
                new Category(){Name = "Круасаны"},
                new Category(){Name = "Пицца"},
                new Category(){Name = "Другое"},
            };

            var products = new List<Product>{
                new Product(){Name = "Пиво", CategoryId = 1},
                new Product(){Name = "Пиво", CategoryId = 1},
                new Product(){Name = "Пиво", CategoryId = 1},
                new Product(){Name = "Пиво", CategoryId = 2},
                new Product(){Name = "Пиво", CategoryId = 2},
                new Product(){Name = "Пиво", CategoryId = 2},
                new Product(){Name = "Пиво", CategoryId = 3},
                new Product(){Name = "Пиво", CategoryId = 3},
                new Product(){Name = "Пиво", CategoryId = 4},
                new Product(){Name = "Пиво", CategoryId = 5},
                new Product(){Name = "Пиво", CategoryId = 5},
                new Product(){Name = "Пиво", CategoryId = 5},
                new Product(){Name = "Пиво", CategoryId = 5},
            };

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var categoryRepository = serviceScope.ServiceProvider.GetService<ICategoryRepository>();
                categories.ForEach(async category => await categoryRepository.CreateCategory(category));

                var productRepository = serviceScope.ServiceProvider.GetService<IProductRepository>();
                products.ForEach(async product => await productRepository.CreateProduct(product));
            }
        }
    }
}