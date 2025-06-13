namespace CalculoImposto.Api.Application.DTOs
{
    public class CalculoImpostosDto
    {
        public decimal ValorPedido {  get; set; }
        public decimal ?ValorICMS { get; set; }
        public decimal ?ValorPIS { get; set; }
        public decimal ?ValorCOFINS { get; set; }
        public decimal valorTotalImpostos { get; set; }
        public decimal valorTotal {  get; set; }
    }
}
