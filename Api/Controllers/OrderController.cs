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
            Console.WriteLine("--> Hitted CreateOrder");

            if (request.Positions.Count < 1)
                return BadRequest();

            var result = await _orderService.CreateOrder(request);

            return result ? Ok() : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderShortReadDto>>> GetOrders(string userName)
        {
            Console.WriteLine("--> Hitted GetOrders");

            return Ok(await _orderService.GetUserOrders(userName));
        }

        //auth or check user
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
        {
            Console.WriteLine("--> Hitted GetOrder");

            var order = await _orderService.GetOrderById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }


        //auth or check user
        [HttpPatch("{id}/status")]
        public async Task<ActionResult<OrderReadDto>> ChangeStatus(int id, [FromQuery] int targetStatus)
        {
            Console.WriteLine("--> Hitted ChangeStatus");

            try
            {
                await _orderService.ChangeOrderStatus(id, targetStatus);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}