using CalculoImposto.Api.Domain.Entities;

namespace CalculoImposto.Tests.Domain.Entities
{
    public class PedidoTests
    {
        [Fact]
        public void ValorTotal_DeveRetornarSomaDosProdutos()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "RJ", DateOnly.FromDateTime(DateTime.Today));
            pedido.Produtos = new List<Produto>
            {
                new Produto(1, "Mouse", 50.35m),
                new Produto(2, "Teclado", 142.20m)
            };

            // Act
            var total = pedido.ValorTotal;

            // Assert
            Assert.Equal(192.55m, total);
        }
    }
}
