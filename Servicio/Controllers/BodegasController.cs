using Comun;
using Controlador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize]
    public class BodegasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BodegasController> _logger;
        private readonly BodegasCtl _bodegasCtl;
        public BodegasController(IConfiguration configuration, ILogger<BodegasController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _bodegasCtl = new BodegasCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get(Bodegas bodegas) {
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

            return Ok(_bodegasCtl.ObtenerTodos(bodegas));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearBodega(Bodegas bodegas)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _bodegasCtl.Crear(bodegas);
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
        public IActionResult ActualizarBodega(Bodegas bodegas)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _bodegasCtl.Actualizar(bodegas);
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
        public IActionResult EliminarBodega(Bodegas bodegas)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _bodegasCtl.Eliminar(bodegas);
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
