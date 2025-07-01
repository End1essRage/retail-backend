using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int Parent { get; set; }
        public bool IsActive { get; set; }
    }
}