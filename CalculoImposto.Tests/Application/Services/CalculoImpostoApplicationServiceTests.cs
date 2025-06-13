using CalculoImposto.Api.Application.DTOs;
using CalculoImposto.Api.Application.Services;
using CalculoImposto.Api.Domain.Entities;
using Moq;
using CalculoImposto.Api.Domain.Interfaces;

namespace CalculoImposto.Tests.Application.Services
{
    public class CalculoImpostosApplicationServiceTests
    {
        [Fact]
        public void CalcularImpostoICMS_DeveRetornarValoresCorretos()
        {
            // Arrange
            var mockDomainService = new Mock<ICalculoImpostoDomainService>();
            var service = new CalculoImpostosApplicationService(mockDomainService.Object);

            var pedidoDto = new PedidoRequestDto
            {
                Id = 1,
                UfOrigem = "SP",
                UfDestino = "RJ",
                Data = DateOnly.FromDateTime(DateTime.Today),
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto { Id = 1, Nome = "Mouse", Valor = 100 },
                    new ProdutoDto { Id = 2, Nome = "Teclado", Valor = 200 }
                }
            };

            var pedido = new Pedido(1, "SP", "RJ", pedidoDto.Data);
            pedido.AdicionarProduto(new Produto(1, "Mouse", 100));
            pedido.AdicionarProduto(new Produto(2, "Teclado", 200));

            // Setup dos mocks dos Serviços de Domínio
            mockDomainService.Setup(s => s.CalcularICMS(It.IsAny<Pedido>())).Returns(36m);

            // Act
            var resultado = service.CalcularImpostos(pedidoDto, icms: true, pis: false, cofins: false);

            // Assert
            Assert.Equal(300, resultado.ValorPedido);
            Assert.Equal(36, resultado.ValorICMS);
            Assert.Null( resultado.ValorPIS);
            Assert.Null( resultado.ValorCOFINS);
            Assert.Equal(36, resultado.ValorTotalImpostos);
            Assert.Equal(336, resultado.ValorTotal);
        }

        [Fact]
        public void CalcularImpostoPIS_DeveRetornarValoresCorretos()
        {
            // Arrange
            var mockDomainService = new Mock<ICalculoImpostoDomainService>();
            var service = new CalculoImpostosApplicationService(mockDomainService.Object);

            var pedidoDto = new PedidoRequestDto
            {
                Id = 1,
                UfOrigem = "SP",
                UfDestino = "RJ",
                Data = DateOnly.FromDateTime(DateTime.Today),
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto { Id = 1, Nome = "Mouse", Valor = 135.40m },
                    new ProdutoDto { Id = 2, Nome = "Teclado", Valor = 85.32m }
                }
            };

            var pedido = new Pedido(1, "SP", "RJ", pedidoDto.Data);
            pedido.AdicionarProduto(new Produto(1, "Mouse", 135.40m));
            pedido.AdicionarProduto(new Produto(2, "Teclado", 85.32m));

            // Setup dos mocks dos Serviços de Domínio
            mockDomainService.Setup(s => s.CalcularPIS(It.IsAny<Pedido>())).Returns(3.64188m);

            // Act
            var resultado = service.CalcularImpostos(pedidoDto, icms: false, pis: true, cofins: false);

            // Assert
            Assert.Equal(220.72m, resultado.ValorPedido);
            Assert.Null( resultado.ValorICMS);
            Assert.Equal(3.64188m, resultado.ValorPIS);
            Assert.Null( resultado.ValorCOFINS);
            Assert.Equal(3.64188m, resultado.ValorTotalImpostos);
            Assert.Equal(224.36188m, resultado.ValorTotal);
        }

        [Fact]
        public void CalcularImpostoCOFINS_DeveRetornarValoresCorretos()
        {
            // Arrange
            var mockDomainService = new Mock<ICalculoImpostoDomainService>();
            var service = new CalculoImpostosApplicationService(mockDomainService.Object);

            var pedidoDto = new PedidoRequestDto
            {
                Id = 1,
                UfOrigem = "SP",
                UfDestino = "RJ",
                Data = DateOnly.FromDateTime(DateTime.Today),
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto { Id = 1, Nome = "Mouse", Valor = 100 },
                    new ProdutoDto { Id = 2, Nome = "Teclado", Valor = 200 }
                }
            };

            var pedido = new Pedido(1, "SP", "RJ", pedidoDto.Data);
            pedido.AdicionarProduto(new Produto(1, "Mouse", 100));
            pedido.AdicionarProduto(new Produto(2, "Teclado", 200));

            // Setup dos mocks dos Serviços de Domínio
            mockDomainService.Setup(s => s.CalcularCOFINS(It.IsAny<Pedido>())).Returns(15.0m);

            // Act
            var resultado = service.CalcularImpostos(pedidoDto, icms: false, pis: false, cofins: true);

            // Assert
            Assert.Equal(300, resultado.ValorPedido);
            Assert.Null(resultado.ValorICMS);
            Assert.Null(resultado.ValorPIS);
            Assert.Equal(15, resultado.ValorCOFINS);
            Assert.Equal(15, resultado.ValorTotalImpostos);
            Assert.Equal(315, resultado.ValorTotal);
        }

        [Fact]
        public void CalcularImpostos_DeveRetornarValoresCorretos()
        {
            // Arrange
            var mockDomainService = new Mock<ICalculoImpostoDomainService>();
            var service = new CalculoImpostosApplicationService(mockDomainService.Object);

            var pedidoDto = new PedidoRequestDto
            {
                Id = 1,
                UfOrigem = "SP",
                UfDestino = "RJ",
                Data = DateOnly.FromDateTime(DateTime.Today),
                Produtos = new List<ProdutoDto>
                {
                    new ProdutoDto { Id = 1, Nome = "Mouse", Valor = 100 },
                    new ProdutoDto { Id = 2, Nome = "Teclado", Valor = 200 }
                }
            };

            var pedido = new Pedido(1, "SP", "RJ", pedidoDto.Data);
            pedido.AdicionarProduto(new Produto(1, "Mouse", 100));
            pedido.AdicionarProduto(new Produto(2, "Teclado", 200));

            // Setup dos mocks dos Serviços de Domínio
            mockDomainService.Setup(s => s.CalcularICMS(It.IsAny<Pedido>())).Returns(36m);
            mockDomainService.Setup(s => s.CalcularPIS(It.IsAny<Pedido>())).Returns(5m);
            mockDomainService.Setup(s => s.CalcularCOFINS(It.IsAny<Pedido>())).Returns(15m);

            // Act
            var resultado = service.CalcularImpostos(pedidoDto, icms: true, pis: true, cofins: true);

            // Assert
            Assert.Equal(300, resultado.ValorPedido);
            Assert.Equal(36, resultado.ValorICMS);
            Assert.Equal(5, resultado.ValorPIS);
            Assert.Equal(15, resultado.ValorCOFINS);
            Assert.Equal(56, resultado.ValorTotalImpostos);
            Assert.Equal(356, resultado.ValorTotal);
        }
    }
}
