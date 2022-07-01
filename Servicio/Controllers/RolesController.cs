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
    public class RolesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RolesController> _logger;
        private readonly RolesCtl _rolesCtl;
        public RolesController(IConfiguration configuration, ILogger<RolesController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _rolesCtl = new RolesCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get(Roles roles) {
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

            return Ok(_rolesCtl.ObtenerTodos(roles));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearArticulo(Roles roles)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _rolesCtl.Crear(roles);
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
        public IActionResult ActualizarArticulo(Roles roles)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _rolesCtl.Actualizar(roles);
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
        public IActionResult EliminarArticulo(Roles roles)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _rolesCtl.Eliminar(roles);
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
