using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Api.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public List<Position> Positions { get; set; } = new List<Position>();
        public string Status { get; set; }
    }

    public class OrderShortReadDto
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public int Status { get; set; } = 0;
        public string StatusName { get; set; }
    }

    public class Position
    {
        public ProductReadDto Product { get; set; }
        public int Count { get; set; }
    }
}