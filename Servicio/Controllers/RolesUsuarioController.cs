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
    public class RolesUsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RolesUsuarioController> _logger;
        private readonly RolesUsuarioCtl _rolesusuarioCtl;
        public RolesUsuarioController(IConfiguration configuration, ILogger<RolesUsuarioController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _rolesusuarioCtl = new RolesUsuarioCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] RolesUsuario rolesusuario) {
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

            return Ok(_rolesusuarioCtl.ObtenerTodos(rolesusuario));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearRolUsuario(RolesUsuario rolesusuario)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _rolesusuarioCtl.Crear(rolesusuario);
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
        public IActionResult ActualizarRolUsuario(RolesUsuario rolesusuario)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _rolesusuarioCtl.Actualizar(rolesusuario);
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
        public IActionResult EliminarRolUsuario(RolesUsuario rolesusuario)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _rolesusuarioCtl.Eliminar(rolesusuario);
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
