using CalculoImposto.Api.Application.DTOs;
using CalculoImposto.Api.Application.Interfaces;
using CalculoImposto.Api.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace CalculoImposto.Api.Controllers
{
    /// <summary>
    /// Controller responsável pelo cálculo de impostos para pedidos.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CalculoImpostoController : ControllerBase
    {
        private readonly ICalculoImpostosApplicationService _applicationService;

        public CalculoImpostoController(ICalculoImpostosApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        /// <summary>
        /// Calcula os impostos de um pedido.
        /// </summary>
        /// <param name="pedidoDto">Objeto que contém os dados do pedido.</param>
        /// <param name="icms">Indica se o cálculo de ICMS deve ser realizado.</param>
        /// <param name="pis">Indica se o cálculo de PIS deve ser realizado.</param>
        /// <param name="cofins">Indica se o cálculo de COFINS deve ser realizado.</param>
        /// <returns>Um objeto contendo o resumo do cálculo dos impostos.</returns>
        /// <response code="200">Cálculo realizado com sucesso.</response>
        /// <response code="400">Requisição inválida ou erro na regra de negócios.</response>
        /// <response code="500">Erro interno inesperado.</response>
        [HttpPost]
        public IActionResult CalcularImpostos(
            [FromBody] PedidoRequestDto pedidoDto,
            [FromQuery] bool icms,
            [FromQuery] bool pis,
            [FromQuery] bool cofins)
        {

            // TODO: Implementar middelware para tratar os erros.
            try
            {
                CalculoImpostosDto resultado = _applicationService.CalcularImpostos(pedidoDto, icms, pis, cofins);
                return Ok(resultado);
            }
            catch (ApplicationServiceException applicationException)
            {
                return BadRequest(applicationException.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro desconhecido.");
            }


        }

    }
}
