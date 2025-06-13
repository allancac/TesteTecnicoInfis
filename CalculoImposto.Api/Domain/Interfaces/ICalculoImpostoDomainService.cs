using CalculoImposto.Api.Domain.Entities;

namespace CalculoImposto.Api.Domain.Interfaces
{
    public interface ICalculoImpostoDomainService
    {
        decimal CalcularICMS(Pedido pedido);
        decimal CalcularPIS(Pedido pedido);
        decimal CalcularCOFINS(Pedido pedido);
    }
}
