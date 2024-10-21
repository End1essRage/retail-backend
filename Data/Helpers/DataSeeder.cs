using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Data.Entities;
using retail_backend.Data.Repositories;
using retail_backend.Data.Repositories.Abstractions;

namespace retail_backend.Data.Helpers
{
    public static class DataSeeder
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            var categories = new List<Category>
            {
                new Category(){Id = 1, Name = "Осетинские пироги"},
                new Category(){Id = 2,Name = "Хачапури"},
                new Category(){Id = 3,Name = "Сеты"},
                new Category(){Id = 4,Name = "Пицца"},
                new Category(){Id = 5,Name = "Выпечка"},
                new Category(){Id = 6,Name = "Хлеб"},
                new Category(){Id = 7,Name = "Десерты"},
                new Category(){Id = 8,Name = "Напитки"},
                //parents
            };

            var products = new List<Product>{
                new Product(){Name = "Осетинский пирог с Мясом", CategoryId = 1, Description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"},
                new Product(){Name = "Осетинский пирог с Картофелем", CategoryId = 1, Description = ""},
                new Product(){Name = "Осетинский пирог с Индейкой", CategoryId = 1, Description = ""},
                new Product(){Name = "Хачапури По-имеретински", CategoryId = 2, Description = ""},
                new Product(){Name = "Хачапури По-мигрельски", CategoryId = 2, Description = ""},
                new Product(){Name = "Хачапури Пщ-аджарски с мясом", CategoryId = 2, Description = ""},
                new Product(){Name = "Хачапури по-имеретински, по аджарски и кока кола", CategoryId = 3, Description = ""},
                new Product(){Name = "Сет с осетинскими пирогами", CategoryId = 3, Description = ""},
                new Product(){Name = "Пицца Мясная", CategoryId = 4, Description = ""},
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
                categories.ForEach(category => categoryRepository.Create(category));

                var productRepository = serviceScope.ServiceProvider.GetService<IProductRepository>();
                products.ForEach(product => productRepository.Create(product));

                var userRepository = serviceScope.ServiceProvider.GetService<IUserRepository>();
                userRepository.Create(new TelegramUser() { UserName = "envyloup", Role = UserRole.Manager });

                await categoryRepository.SaveChangesAsync();
            }
        }
    }
}