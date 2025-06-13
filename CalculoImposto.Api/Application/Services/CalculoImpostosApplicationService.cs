using CalculoImposto.Api.Application.DTOs;
using CalculoImposto.Api.Domain.Entities;
using CalculoImposto.Api.Application.Interfaces;
using CalculoImposto.Api.Domain.Interfaces;

namespace CalculoImposto.Api.Application.Services
{
    public class CalculoImpostosApplicationService : ICalculoImpostosApplicationService
    {
        private readonly ICalculoImpostoDomainService _calculoImpostoDomainService;

        public CalculoImpostosApplicationService(ICalculoImpostoDomainService calculoImpostoDomainService)
        {
            _calculoImpostoDomainService = calculoImpostoDomainService;
        }
        public CalculoImpostosDto CalcularImpostos(PedidoRequestDto pedidoDto, bool icms, bool pis, bool cofins)
        {
            

            // TODO: Usar AutoMapper para mapear PedidoRequestDto para a entidade Pedido
            Pedido pedidoEntity = new Pedido(pedidoDto.Id, pedidoDto.UfOrigem, pedidoDto.UfDestino, pedidoDto.Data);
            foreach (var produtoDto in pedidoDto.Produtos)
            {
                pedidoEntity.AdicionarProduto(new Produto(
                        produtoDto.Id,
                        produtoDto.Nome,
                        produtoDto.Valor
                    )
                );
            }

            CalculoImpostosDto calculoImpostosDto = new CalculoImpostosDto();
            calculoImpostosDto.PedidoId = pedidoEntity.PedidoId;
            calculoImpostosDto.ValorPedido = pedidoEntity.ValorTotal;
            calculoImpostosDto.ValorICMS = icms ? _calculoImpostoDomainService.CalcularICMS(pedidoEntity) : null;
            calculoImpostosDto.ValorPIS = pis ? _calculoImpostoDomainService.CalcularPIS(pedidoEntity) : null;
            calculoImpostosDto.ValorCOFINS = cofins ? _calculoImpostoDomainService.CalcularCOFINS(pedidoEntity) : null;
            calculoImpostosDto.ValorTotalImpostos = (calculoImpostosDto.ValorICMS ?? 0) + (calculoImpostosDto.ValorPIS ?? 0) + (calculoImpostosDto.ValorCOFINS ?? 0);
            calculoImpostosDto.ValorTotal = calculoImpostosDto.ValorPedido + calculoImpostosDto.ValorTotalImpostos;

            return calculoImpostosDto;
        }

    }
}
