using PedidosAPI.Domain.Enums;

namespace PedidosAPI.Domain.Entities
{
    public class Order
    {

        public Guid Id { get; private set; }

        public string NumeroPedido { get; private set; }

        public string ClienteNome { get; private set; }

        public decimal ValorTotal { get; private set; }

        public OrderStatus Status { get; private set; }

        public DateTime CriadoEm { get; private set; }

        public DateTime AtualizadoEm { get; private set; }


        public Order(
            Guid id,
            string numeroPedido,
            string clienteNome,
            decimal valorTotal,
            OrderStatus status,
            DateTime criadoEm,
            DateTime atualizadoEm)
        {
            Id = id;
            NumeroPedido = numeroPedido;
            ClienteNome = clienteNome;
            ValorTotal = valorTotal;
            Status = status;
            CriadoEm = criadoEm;
            AtualizadoEm = atualizadoEm;
        }


        public void AtualizarStatus(OrderStatus novoStatus)
        {
            Status = novoStatus;
            AtualizadoEm = DateTime.UtcNow;
        }

    }
}
