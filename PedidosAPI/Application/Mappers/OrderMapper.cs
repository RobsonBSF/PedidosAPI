using PedidosAPI.Application.DTOs;
using PedidosAPI.Domain.Entities;

namespace PedidosAPI.Application.Mappers
{
    public class OrderMapper
    {
        public static OrderResponseDto ToDto(Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                NumeroPedido = order.NumeroPedido,
                ClienteNome = order.ClienteNome,
                ValorTotal = order.ValorTotal,
                Status = order.Status.ToString(),
                CriadoEm = order.CriadoEm,
                AtualizadoEm = order.AtualizadoEm
            };
        }

    }
}
