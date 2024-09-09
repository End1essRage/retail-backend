using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Api.Dtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public int? Parent { get; set; }
    }
}