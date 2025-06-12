using CalculoImposto.Api.Domain.Entities;
using CalculoImposto.Api.Domain.Services;

namespace CalculoImposto.Tests.Domain.Services
{
    public class CalculoImpostoDomainServiceTests
    {
        private readonly CalculoImpostoDomainService _calculoImpostoDomainService;

        public CalculoImpostoDomainServiceTests()
        {
            _calculoImpostoDomainService = new CalculoImpostoDomainService();
        }

        [Fact]
        public void IcmsDifUFTests()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "RJ", DateOnly.FromDateTime(DateTime.Today));
            pedido.AdicionarProduto(new Produto(1, "Mouse", 50.35m));
            pedido.AdicionarProduto(new Produto(2, "Teclado", 142.20m));

            // Act
            var resultado = _calculoImpostoDomainService.CalcularICMS(pedido);

            // Assert
            Assert.Equal(23.106m, resultado);
        }

        [Fact]
        public void IcmsMesmaUFTests()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "SP", DateOnly.FromDateTime(DateTime.Today));
            pedido.AdicionarProduto(new Produto(1, "Monitor 23 Polegadas", 980.5m));
            pedido.AdicionarProduto(new Produto(2, "Monitor 32 Polegadas", 1590.95m));
            pedido.AdicionarProduto(new Produto(3, "Telefone Celular Samsung", 1985.45m));


            // Act
            var resultado = _calculoImpostoDomainService.CalcularICMS(pedido);

            // Assert
            Assert.Equal(4556.9m * (18.0m / 100.0m), resultado);
        }

        [Fact]
        public void PisTests()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "SP", DateOnly.FromDateTime(DateTime.Today));
            pedido.AdicionarProduto(new Produto(1, "Monitor 32 Polegadas", 1590.95m));
            pedido.AdicionarProduto(new Produto(2, "Telefone Celular Samsung", 1985.45m));

            // Act
            var resultado = _calculoImpostoDomainService.CalcularPIS(pedido);

            // Assert
            Assert.Equal(3576.4m * (1.65m / 100.0m), resultado);
        }

        [Fact]
        public void CofinsTests()
        {
            // Arrange
            var pedido = new Pedido(1, "SP", "SP", DateOnly.FromDateTime(DateTime.Today));
            pedido.AdicionarProduto(new Produto(1, "Monitor 32 Polegadas", 1590.95m));
            pedido.AdicionarProduto(new Produto(2, "Telefone Celular Samsung", 1985.45m));

            // Act
            var resultado = _calculoImpostoDomainService.CalcularCOFINS(pedido);

            // Assert
            Assert.Equal( 3576.4m * (7.6m/100.0m), resultado);
        }

    }
}
