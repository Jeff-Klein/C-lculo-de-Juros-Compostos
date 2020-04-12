using System.Threading.Tasks;
using CalculoDeJuros.Business.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculoDeJuros.API.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class CalculoDeJurosController : ControllerBase
    {
        private readonly ICalculoDeJurosService _calculoDeJurosService;

        public CalculoDeJurosController(ICalculoDeJurosService calculoDeJurosService)
        {
            _calculoDeJurosService = calculoDeJurosService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> Get([FromQuery] decimal valorInicial, [FromQuery] int meses)
            => Ok(string.Format("{0:f2}", await _calculoDeJurosService.CalcularJurosCompostos(valorInicial, meses)));
    }
}
