using System.Text.Json;
using CalculoImposto.Api.Domain.Exceptions;
namespace CalculoImposto.Api.Domain.Entities
{
    public class Produto
    {
        public long ProdutoId { set; get; }
        public string Nome { set; get; }
        private decimal _preco;
        public decimal Preco
        {
            set
            {
                if (value <= 0) throw new DomainException("O Preço deve ser um valor positivo.");
                else _preco = value;
            }
            get
            {
               return _preco;
            }
        }

        public Produto(long produtoId, string nome, decimal preco)
        {
            this.ProdutoId = produtoId;
            this.Nome = nome;
            this.Preco = preco;
        }
    
        public override bool Equals(object? obj)
        {
            if (obj is Produto other)
            {
                return this.ProdutoId == other.ProdutoId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ProdutoId.GetHashCode();
        }

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
