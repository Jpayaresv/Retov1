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
    public class TipoMovimientoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TipoMovimientoController> _logger;
        private readonly TipoMovimientoCtl _tipomovimientoCtl;
        public TipoMovimientoController(IConfiguration configuration, ILogger<TipoMovimientoController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _tipomovimientoCtl = new TipoMovimientoCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] TipoMovimiento tipomovimiento) {
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

            return Ok(_tipomovimientoCtl.ObtenerTodos(tipomovimiento));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearTipoMovimiento(TipoMovimiento tipomovimiento)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _tipomovimientoCtl.Crear(tipomovimiento);
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
        public IActionResult ActualizarTipoMovimiento(TipoMovimiento tipomovimiento)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _tipomovimientoCtl.Actualizar(tipomovimiento);
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
        public IActionResult EliminarTipoMovimiento(TipoMovimiento tipomovimiento)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _tipomovimientoCtl.Eliminar(tipomovimiento);
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
