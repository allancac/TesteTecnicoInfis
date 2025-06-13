using CalculoImposto.Api.Application.DTOs;
using CalculoImposto.Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoImposto.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CalculoImpostoController : ControllerBase
    {
        private readonly ICalculoImpostosApplicationService _applicationService;

        public CalculoImpostoController(ICalculoImpostosApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // POST: api/v1/calculoimposto?icms=true&pis=true&cofins=true
        [HttpPost]
        public IActionResult CalcularImpostos(
            [FromBody] PedidoRequestDto pedidoDto,
            [FromQuery] bool icms,
            [FromQuery] bool pis,
            [FromQuery] bool cofins)
        {
            if (pedidoDto == null)
                return BadRequest("Pedido inválido.");

            CalculoImpostosDto resultado = _applicationService.CalcularImpostos(pedidoDto, icms, pis, cofins);
            return Ok(resultado);
        }

    }
}
