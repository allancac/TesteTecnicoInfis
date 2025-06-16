namespace CalculoImposto.Api.Application.DTOs
{
    /// <summary>
    /// Representa um produto que faz parte de um pedido.
    /// </summary>
    public class ProdutoDto
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; } = null!;

        /// <summary>
        /// Valor unitário do produto.
        /// </summary>
        public decimal Valor { get; set; }
    }
}
