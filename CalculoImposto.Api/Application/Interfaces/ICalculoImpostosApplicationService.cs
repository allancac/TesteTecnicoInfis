using CalculoImposto.Api.Application.DTOs;

namespace CalculoImposto.Api.Application.Interfaces
{
    public interface ICalculoImpostosApplicationService
    {
        CalculoImpostosDto CalcularImpostos(PedidoRequestDto pedidoDto, bool icms, bool pis, bool cofins);
    }
}