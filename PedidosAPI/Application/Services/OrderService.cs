using Microsoft.EntityFrameworkCore;
using PedidosAPI.Application.Exceptions;
using PedidosAPI.Domain.Entities;
using PedidosAPI.Domain.Enums;
using PedidosAPI.Infrastructure.Data;

namespace PedidosAPI.Application.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new NotFoundException("Pedido não encontrado");
            }

            return order;
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new NotFoundException("Pedido não encontrado");
            }

            if (order.Status == OrderStatus.CANCELED)
            {
                throw new BusinessException("Pedido já está cancelado");
            }

            if (order.Status == OrderStatus.INVOICED)
            {
                throw new BusinessException("Pedido faturado não pode ser cancelado");
            }

            order.AtualizarStatus(OrderStatus.CANCELED);

            await _context.SaveChangesAsync();
        }

    }
}