using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using retail_backend.Api.Dtos;
using retail_backend.Data.Entities;

namespace retail_backend.Service
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderRequest request);
        Task<List<OrderShortReadDto>> GetUserOrders(string userName);
        Task<OrderReadDto> GetOrderById(int orderId);
    }
}