using CalculoImposto.Api.Domain.Entities;
using CalculoImposto.Api.Domain.Exceptions;
using CalculoImposto.Api.Domain.Interfaces;

namespace CalculoImposto.Api.Domain.Services
{
    public class CalculoImpostoDomainService: ICalculoImpostoDomainService
    {
        public const decimal ICMS_MESMA_UF = 0.18m;
        public const decimal ICMS_DIF_UF = 0.12m;
        public const decimal PIS = 0.0165m;
        public const decimal COFINS = 0.076m;

        public decimal CalcularICMS(Pedido pedido)
        {
            ValidarPedido(pedido);
            var aliquota = (pedido.UfOrigem == pedido.UfDestino) ? ICMS_MESMA_UF : ICMS_DIF_UF;
            return pedido.ValorTotal * aliquota;
        }

        public decimal CalcularPIS(Pedido pedido)
        {
            ValidarPedido(pedido);
            return pedido.ValorTotal * PIS;
        }

        public decimal CalcularCOFINS(Pedido pedido)
        {
            ValidarPedido(pedido);
            return pedido.ValorTotal * COFINS;
        }

        private static void ValidarPedido(Pedido pedido)
        {
            if (pedido == null)
                throw new DomainException("O pedido não pode ser nulo.");

            if (pedido.Produtos == null || !pedido.Produtos.Any())
                throw new DomainException("O pedido deve conter ao menos um produto.");

            if (pedido.ValorTotal <= 0)
                throw new DomainException("O valor total do pedido deve ser positivo.");

            if (string.IsNullOrWhiteSpace(pedido.UfOrigem))
                throw new DomainException("UF de origem não informada.");

            if (string.IsNullOrWhiteSpace(pedido.UfDestino))
                throw new DomainException("UF de destino não informada.");
        }
    }

}
