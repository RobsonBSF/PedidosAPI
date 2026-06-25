
using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.Services;
using PedidosAPI.Application.Mappers;
using PedidosAPI.Application.DTOs;


namespace PedidosAPI.Controllers
{

    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponseDto>>> GetAll()
        {
            var orders = await _service.GetAllAsync();

            var result = orders.Select(OrderMapper.ToDto).ToList();

            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderResponseDto>> GetById(Guid orderId)
        {
            var order = await _service.GetByIdAsync(orderId);

            return Ok(OrderMapper.ToDto(order));
        }


        [HttpPost("{orderId}/cancel")]
        public async Task<IActionResult> Cancel(Guid orderId)
        {
            await _service.CancelOrderAsync(orderId);

            return Ok(new
            {
                message = "Pedido cancelado com sucesso"
            });
        }

    }
}
