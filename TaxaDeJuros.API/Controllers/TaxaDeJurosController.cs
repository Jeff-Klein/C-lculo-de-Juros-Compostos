using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxaDeJuros.API.Dominio.Repositorios;

namespace TaxaDeJuros.API.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class TaxaDeJurosController : ControllerBase
    {
        private readonly ITaxaRepositorio _taxaRepositorio;

        public TaxaDeJurosController(ITaxaRepositorio taxaRepositorio)
        {
            _taxaRepositorio = taxaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<double>> Get()
            => Ok((await _taxaRepositorio.ObterTaxaDeJurosAsync()).Percentual);
    }
}
