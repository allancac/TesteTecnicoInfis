namespace CalculoImposto.Api.Application.DTOs
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
