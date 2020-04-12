using Autenticacao.API.Dominio.Repositorios;
using Autenticacao.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Autenticacao.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AutenticacaoController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> Autenticar([FromQuery]string userName, [FromQuery]string senha)
        {
            var usuario = await _usuarioRepositorio.ObterPorUserNameAsync(userName);

            if (usuario == null)
                return NotFound();
            else if (usuario.Senha != senha)
                return Unauthorized();
            else
                return Ok(TokenService.GerarToken());
        }

        [HttpGet("validar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> Validar([FromQuery]string token)
        {
            if (!TokenService.ValidarToken(token))
                return Unauthorized();
            else
                return Ok();
        }
    }
}
