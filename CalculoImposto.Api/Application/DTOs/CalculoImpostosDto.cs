namespace CalculoImposto.Api.Application.DTOs
{
    public class CalculoImpostosDto
    {
        public long PedidoId { get; set; }
        public decimal ValorPedido {  get; set; }
        public decimal ?ValorICMS { get; set; }
        public decimal ?ValorPIS { get; set; }
        public decimal ?ValorCOFINS { get; set; }
        public decimal ValorTotalImpostos { get; set; }
        public decimal ValorTotal {  get; set; }
    }
}
