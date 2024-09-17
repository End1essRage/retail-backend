using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using retail_backend.Api.Dtos;
using retail_backend.Data.Entities;
using retail_backend.Service;

namespace retail_backend.Api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            await _orderService.CreateOrder(request);
            return Ok(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders(string userName)
        {
            return Ok(userName);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return Ok(id);
        }
    }
}