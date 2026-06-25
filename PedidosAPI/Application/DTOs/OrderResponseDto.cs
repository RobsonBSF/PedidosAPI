namespace PedidosAPI.Application.DTOs
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }

        public string NumeroPedido { get; set; }

        public string ClienteNome { get; set; }

        public decimal ValorTotal { get; set; }

        public string Status { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

    }
}
