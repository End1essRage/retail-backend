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
                new Category(){Id = 1, Name = "Осетинские пироги", Parent = 2},
                new Category(){Name = "Хачапури"},
                new Category(){Name = "Сеты"},
                new Category(){Name = "Пицца"},
                new Category(){Name = "Выпечка"},
                new Category(){Name = "Хлеб", Parent = 5},
                new Category(){Name = "Десерты"},
                new Category(){Name = "Напитки"},
            };

            var products = new List<Product>{
                new Product(){Name = "С Мясом", CategoryId = 1, Description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"},
                new Product(){Name = "С Картофелем", CategoryId = 1, Description = ""},
                new Product(){Name = "С Индейкой", CategoryId = 1, Description = ""},
                new Product(){Name = "По-имеретински", CategoryId = 2, Description = ""},
                new Product(){Name = "По-мигрельски", CategoryId = 2, Description = ""},
                new Product(){Name = "Пщ-аджарски с мясом", CategoryId = 2, Description = ""},
                new Product(){Name = "Хачапури по-имеретински, по аджарски и кока кола", CategoryId = 3, Description = ""},
                new Product(){Name = "Сет с осетинскими пирогами", CategoryId = 3, Description = ""},
                new Product(){Name = "Мясная", CategoryId = 4, Description = ""},
                new Product(){Name = "Плюшка Московская", CategoryId = 5, Description = ""},
                new Product(){Name = "Круасан классический", CategoryId = 5, Description = ""},
                new Product(){Name = "Улитка с маком", CategoryId = 5, Description = ""},
                new Product(){Name = "Улитка с маком в шоколадной глазури", CategoryId = 5, Description = ""},
                new Product(){Name = "батон нарезной сна закваске", CategoryId = 6, Description = ""},
                new Product(){Name = "дарницкий хлеб на закваске", CategoryId = 6, Description = ""},
                new Product(){Name = "Безе на палочке", CategoryId = 7, Description = ""},
                new Product(){Name = "Безе в стакане", CategoryId = 7, Description = ""},
                new Product(){Name = "Кока-кола", CategoryId = 8, Description = ""},
                new Product(){Name = "Фанта", CategoryId = 8, Description = ""},
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