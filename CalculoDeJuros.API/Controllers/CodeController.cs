using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculoDeJuros.API.Controllers
{
    [ApiController]
    [Route("showmethecode")]
    public class CodeController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Get()
            => Ok("https://github.com/Jeff-Klein/C-lculo-de-Juros-Compostos");
    }
}