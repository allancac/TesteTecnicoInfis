namespace CalculoImposto.Api.Application.DTOs
{
    /// <summary>
    /// Representa os dados de entrada de um pedido para cálculo de impostos.
    /// </summary>
    public class PedidoRequestDto
    {
        /// <summary>
        /// Identificador do pedido.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unidade Federativa (UF) de origem do pedido.
        /// </summary>
        public string UfOrigem { get; set; } = null!;

        /// <summary>
        /// Unidade Federativa (UF) de destino do pedido.
        /// </summary>
        public string UfDestino { get; set; } = null!;

        /// <summary>
        /// Data do pedido.
        /// </summary>
        public DateOnly Data { get; set; }

        /// <summary>
        /// Lista de produtos incluídos no pedido.
        /// </summary>
        public List<ProdutoDto> Produtos { get; set; } = new();

        /// <summary>
        /// Valor total dos produtos do pedido (soma dos valores unitários dos produtos).
        /// </summary>
        public decimal ValorTotal
        {
            get { return Produtos.Sum(prod => prod.Valor); }
        }
    }
}
