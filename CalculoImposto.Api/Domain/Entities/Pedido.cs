namespace CalculoImposto.Api.Domain.Entities
{
    public class Pedido
    {
        public long PedidoId { get; set; } 
        public string UfOrigem { get; set; }
        public string UfDestino {  get; set; }
        public DateOnly DataPedido { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal ValorTotal => Produtos.Sum(produto=>produto.Preco);

        public Pedido(long pedidoId, string ufOrigem, string ufDestino, DateOnly dataPedido)
        {
            PedidoId = pedidoId;
            UfOrigem = ufOrigem;
            UfDestino = ufDestino;
            DataPedido = dataPedido;
            Produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto prod)
        {
            this.Produtos.Add(prod);
        }

    }
}
