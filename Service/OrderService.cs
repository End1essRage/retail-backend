using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using retail_backend.Api.Dtos;
using retail_backend.Data.Entities;
using retail_backend.Data.Helpers;
using retail_backend.Data.Repositories;

namespace retail_backend.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapepr;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo, IMapper mapepr)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _mapepr = mapepr;
        }

        public async Task CreateOrder(CreateOrderRequest request)
        {
            var order = new Order()
            {
                Status = DataConstants.OrderStatus_New,
                ClientUserName = request.UserName,
                Positions = request.Positions
            };

            _orderRepo.Create(order);

            await _orderRepo.SaveChangesAsync();
        }

        public async Task<List<OrderShortReadDto>> GetUserOrders(string userName)
        {
            var order = await _orderRepo.GetUserOrdersAsync(userName);

            return _mapepr.Map<List<OrderShortReadDto>>(order);
        }

        public async Task<OrderReadDto> GetOrderById(int orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            //Получаем все продукты
            var ids = new List<int>();
            foreach (var pos in order.Positions)
            {
                ids.Add(pos.Key);
            }

            var products = await _productRepo.GetProductsByIds(ids);
            var productDtos = _mapepr.Map<List<ProductReadDto>>(products);

            var orderDto = new OrderReadDto();
            orderDto.Status = DataConstants.OrderStatus_New;
            orderDto.Id = order.Id;

            foreach (var pos in order.Positions)
            {
                var product = productDtos.SingleOrDefault(p => p.Id == pos.Key);
                if (product == null)
                {
                    throw new Exception("");
                }

                orderDto.Positions.Add(new Position()
                {
                    Product = product,
                    Count = pos.Value
                });
            }

            return orderDto;
        }
    }
}