using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Api.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}