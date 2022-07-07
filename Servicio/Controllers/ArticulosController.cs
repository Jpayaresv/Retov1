using Comun;
using Controlador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticulosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ArticulosController> _logger;
        private readonly ArticulosCtl _articulosCtl;
        public ArticulosController(IConfiguration configuration, ILogger<ArticulosController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _articulosCtl = new ArticulosCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] Articulos articulos) {
/*             RespuestaDto respuesta;
            try
            {
                respuesta = 
                return Ok(_usuariosCtl.ObtenerTodos(usuarios));
            }   
            catch (Exception ex)
            {
                _logger.LogError("{@Exception}", ex);
                respuesta = new RespuestaDto("499", "Error Interno: " + ex.Message, TipoMensajeRespuesta.error);
                return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
            } */

            return Ok(_articulosCtl.ObtenerTodos(articulos));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearArticulo(Articulos articulos)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _articulosCtl.Crear(articulos);
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                _logger.LogError("{@Exception}", ex);
                respuesta = new RespuestaDto("499", "Error Interno: " + ex.Message, TipoMensajeRespuesta.error);
                return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
            }

            return Ok();
        }

        [HttpPost("Actualizar")]
        public IActionResult ActualizarArticulo(Articulos articulos)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _articulosCtl.Actualizar(articulos);
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                _logger.LogError("{@Exception}", ex);
                respuesta = new RespuestaDto("499", "Error Interno: " + ex.Message, TipoMensajeRespuesta.error);
                return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
            }

            return Ok();
        }

        [HttpDelete("Eliminar")]
        public IActionResult EliminarArticulo(Articulos articulos)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _articulosCtl.Eliminar(articulos);
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                _logger.LogError("{@Exception}", ex);
                respuesta = new RespuestaDto("499", "Error Interno: " + ex.Message, TipoMensajeRespuesta.error);
                return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
            }

            return Ok();
        }

        

        
    }
}
