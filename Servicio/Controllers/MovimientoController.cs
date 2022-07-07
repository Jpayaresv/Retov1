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
    public class MovimientoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MovimientoController> _logger;
        private readonly MovimientoCtl _movimientoCtl;
        public MovimientoController(IConfiguration configuration, ILogger<MovimientoController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _movimientoCtl = new MovimientoCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] Movimiento movimiento) {
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

            return Ok(_movimientoCtl.ObtenerTodos(movimiento));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearMovimiento(Movimiento movimiento)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _movimientoCtl.Crear(movimiento);
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
        public IActionResult ActualizarMovimiento(Movimiento movimiento)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _movimientoCtl.Actualizar(movimiento);
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
        public IActionResult EliminarMovimiento(Movimiento movimiento)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _movimientoCtl.Eliminar(movimiento);
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
