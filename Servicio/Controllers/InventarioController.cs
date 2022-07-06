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
    public class InventarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<InventarioController> _logger;
        private readonly InventarioCtl _inventarioCtl;
        public InventarioController(IConfiguration configuration, ILogger<InventarioController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _inventarioCtl = new InventarioCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] Inventario inventario) {
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

            return Ok(_inventarioCtl.ObtenerTodos(inventario));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearInventario(Inventario inventario)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _inventarioCtl.Crear(inventario);
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
        public IActionResult ActualizarInventario(Inventario inventario)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _inventarioCtl.Actualizar(inventario);
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
        public IActionResult EliminarInventario([FromQuery] Inventario inventario)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _inventarioCtl.Eliminar(inventario);
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
