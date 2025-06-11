namespace CalculoImposto.Api.Domain.Entities
{
    public class Produto
    {
        public long ProdutoId { set; get; }
        public string Nome { set; get; }
        public decimal Preco{ set; get; }

        public Produto(long produtoId, string nome, decimal preco)
        {
            this.ProdutoId = produtoId;
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}
