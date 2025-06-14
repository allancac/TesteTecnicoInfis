using CalculoImposto.Api.Domain.Entities;
using CalculoImposto.Api.Domain.Exceptions;


namespace CalculoImposto.Tests.Domain.Entities
{
    public class ProdutoTests
    {
        [Fact]
        public void PrecoNegativo_DeveLancarDomainException()
        {
            // Act & Assert
            Assert.Throws<DomainException>(() => new Produto(1, "Mouse", 0m));
        }
        [Fact]
        public void ProdutosComMesmoId_DevemSerIguais()
        {
            // Arrange
            var produto1 = new Produto(1, "HD", 200m);
            var produto2 = new Produto(1, "Outro Nome", 300m);

            // Act & Assert
            Assert.True(produto1.Equals(produto2));
            Assert.Equal(produto1.GetHashCode(), produto2.GetHashCode());
        }
        [Fact]
        public void ToString_DeveRetornarJson()
        {
            // Arrange
            var produto = new Produto(1, "Memoria RAM", 250m);

            // Act
            string resultado = produto.ToString();

            // Assert
            Assert.Contains("\"ProdutoId\":1", resultado);
            Assert.Contains("\"Nome\":\"Memoria RAM\"", resultado);
            Assert.Contains("\"Preco\":250", resultado);
        }
    }
}
