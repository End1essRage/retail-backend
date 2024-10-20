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

        public async Task<int> CreateOrder(CreateOrderRequest request)
        {
            var model = new Order()
            {
                Status = OrderStatus.New,
                ClientUserName = request.UserName,
                Positions = request.Positions
            };
            var id = _orderRepo.Create(model);
            await _orderRepo.SaveChangesAsync();
            return id;
        }

        public async Task<List<OrderShortReadDto>> GetUserOrders(string userName)
        {
            var order = await _orderRepo.GetUserOrdersAsync(userName);

            return _mapepr.Map<List<OrderShortReadDto>>(order);
        }

        public async Task<OrderReadDto> GetOrderById(int orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentNullException();
            }

            //Получаем все продукты
            var ids = new List<int>();
            foreach (var pos in order.Positions)
            {
                ids.Add(pos.Key);
            }

            var products = await _productRepo.GetProductsByIds(ids);
            var productDtos = _mapepr.Map<List<ProductReadDto>>(products);

            var orderDto = new OrderReadDto();
            orderDto.Status = DataConstants.OrderStatusDict[order.Status];
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

        public async Task ChangeOrderStatus(int orderId, int targetStatus)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("");

            order.Status = (OrderStatus)targetStatus;

            _orderRepo.Update(order);
            var result = await _orderRepo.SaveChangesAsync();

            if (result < 1)
                throw new Exception();
        }
    }
}