using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace retail_backend.Api.Dtos
{
    public class CreateOrderRequest
    {
        public string UserName { get; set; }
        public Dictionary<int, int> Positions { get; set; } = new Dictionary<int, int>();
    }
}