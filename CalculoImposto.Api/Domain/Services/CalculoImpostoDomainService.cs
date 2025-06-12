using CalculoImposto.Api.Domain.Entities;
using System.Collections;

namespace CalculoImposto.Api.Domain.Services
{
    public class CalculoImpostoDomainService
    {
        public const decimal ICMS_MESMA_UF = 0.18m;
        public const decimal ICMS_DIF_UF = 0.12m;
        public const decimal PIS = 0.0165m;
        public const decimal COFINS = 0.076m;

        public decimal CalcularICMS(Pedido pedido)
        {
            var aliquota = (pedido.UfOrigem == pedido.UfDestino) ? ICMS_MESMA_UF : ICMS_DIF_UF;
            return pedido.ValorTotal * aliquota;
        }

        public decimal CalcularPIS(Pedido pedido)
        {
            return pedido.ValorTotal * PIS;
        }

        public decimal CalcularCOFINS(Pedido pedido)
        {
            return pedido.ValorTotal * COFINS;
        }
    }

}
