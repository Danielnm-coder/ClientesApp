using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        /// <summary>
        /// Serviço para cadastro e clientes
        /// </summary>
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para edição de clientes
        /// </summary>
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para cadastro e clientes
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Serviço para deleção de clientes
        /// </summary>
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
