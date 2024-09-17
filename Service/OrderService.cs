using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using retail_backend.Api.Dtos;
using retail_backend.Data.Entities;
using retail_backend.Data.Repositories;

namespace retail_backend.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task CreateOrder(CreateOrderRequest request)
        {
            var order = new Order()
            {
                Status = OrderStatus.New,
                ClientUserName = request.UserName,
                Positions = request.Positions
            };

            _orderRepo.Create(order);

            await _orderRepo.SaveChangesAsync();
        }

        public async Task<List<Order>> GetUserOrders(string userName)
        {
            return await _orderRepo.GetUserOrdersAsync(userName);
        }
    }
}