namespace CalculoImposto.Api.Application.DTOs
{
    public class PedidoRequestDto
    {
        public int Id { get; set; }
        public string UfOrigem { get; set; } = null!;
        public string UfDestino { get; set; } = null!;
        public DateOnly Data { get; set; }
        public List<ProdutoDto> Produtos { get; set; } = new();
        public decimal ValorTotal { get { return Produtos.Sum(prod => prod.Valor); } }


    }

}
