namespace CalculoImposto.Api.Application.DTOs
{
    /// <summary>
    /// Representa o resultado do cálculo de impostos para um pedido.
    /// </summary>
    public class CalculoImpostosDto
    {
        /// <summary>
        /// Identificador do pedido.
        /// </summary>
        public long PedidoId { get; set; }

        /// <summary>
        /// Valor total dos produtos do pedido, sem impostos.
        /// </summary>
        public decimal ValorPedido { get; set; }

        /// <summary>
        /// Valor calculado do ICMS, caso solicitado.
        /// </summary>
        public decimal? ValorICMS { get; set; }

        /// <summary>
        /// Valor calculado do PIS, caso solicitado.
        /// </summary>
        public decimal? ValorPIS { get; set; }

        /// <summary>
        /// Valor calculado do COFINS, caso solicitado.
        /// </summary>
        public decimal? ValorCOFINS { get; set; }

        /// <summary>
        /// Soma total dos impostos calculados.
        /// </summary>
        public decimal ValorTotalImpostos { get; set; }

        /// <summary>
        /// Valor total do pedido incluindo os impostos.
        /// </summary>
        public decimal ValorTotal { get; set; }
    }
}
