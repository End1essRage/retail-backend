using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using retail_backend.Api.Dtos;

namespace retail_backend.Service
{
    public interface IOrderService
    {
        public Task CreateOrder(CreateOrderRequest request);
    }
}