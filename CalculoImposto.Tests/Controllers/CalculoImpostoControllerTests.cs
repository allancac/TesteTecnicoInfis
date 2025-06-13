using CalculoImposto.Api.Application.DTOs;
using CalculoImposto.Api.Application.Interfaces;
using CalculoImposto.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalculoImposto.Tests.Controllers
{
    public class CalculoImpostoControllerTests
    {
        private readonly Mock<ICalculoImpostosApplicationService> _mockApplicationService;
        private readonly CalculoImpostoController _controller;

        public CalculoImpostoControllerTests()
        {
            _mockApplicationService = new Mock<ICalculoImpostosApplicationService>();
            _controller = new CalculoImpostoController(_mockApplicationService.Object);
        }

        [Fact]
        public void CalcularImpostos_DeveRetornarOk()
        {
            // Arrange
            var pedidoDto = new PedidoRequestDto
            {
                Id = 1,
                UfOrigem = "SP",
                UfDestino = "RJ",
                Data = DateOnly.FromDateTime(DateTime.Today),
                Produtos = new List<ProdutoDto>
        {
            new ProdutoDto { Id = 1, Nome = "Notebook", Valor = 3000 },
            new ProdutoDto { Id = 2, Nome = "Mouse", Valor = 150 }
        }
            };

            var dtoRetorno = new CalculoImpostosDto
            {
                PedidoId = 1,
                ValorPedido = 3150,
                ValorICMS = 300,
                ValorPIS = 50,
                ValorCOFINS = 75,
                ValorTotalImpostos = 425,
                ValorTotal = 3575
            };

            _mockApplicationService.Setup(service => service
                .CalcularImpostos(pedidoDto, true, true, true))
                .Returns(dtoRetorno);

            // Act
            var resultado = _controller.CalcularImpostos(pedidoDto, true, true, true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resultado);
            var dados = Assert.IsType<CalculoImpostosDto>(okResult.Value);

            Assert.Equal(1, dados.PedidoId);
            Assert.Equal(3150, dados.ValorPedido);
            Assert.Equal(300, dados.ValorICMS);
            Assert.Equal(50, dados.ValorPIS);
            Assert.Equal(75, dados.ValorCOFINS);
            Assert.Equal(425, dados.ValorTotalImpostos);
            Assert.Equal(3575, dados.ValorTotal);
        }


    }
}
