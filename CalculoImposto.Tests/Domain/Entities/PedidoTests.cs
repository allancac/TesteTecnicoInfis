using CalculoImposto.Api.Domain.Entities;
using CalculoImposto.Api.Domain.Exceptions;

namespace CalculoImposto.Tests.Domain.Entities
{
    public class PedidoTests
    {

        [Fact]
        public void AdicionarProduto_DeveLancarExcecaoParaPrecoNaoPositivo()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "RJ", DateOnly.FromDateTime(DateTime.Today));
            // Act and assert
            Assert.Throws<DomainException>
                (
                    () => pedido.AdicionarProduto(new Produto(1, "Mouse", 0.0m))
                );

        }
        [Fact]
        public void ValorTotal_DeveRetornarSomaDosProdutos()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "RJ", DateOnly.FromDateTime(DateTime.Today));

            pedido.AdicionarProduto(new Produto(1, "Mouse", 50.35m));
            pedido.AdicionarProduto(new Produto(2, "Teclado", 142.20m));

            // Act
            var total = pedido.ValorTotal;

            // Assert
            Assert.Equal(192.55m, total);
        }



    }
}
