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
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsuariosController> _logger;
        private readonly UsuariosCtl _usuariosCtl;
        public UsuariosController(IConfiguration configuration, ILogger<UsuariosController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _usuariosCtl = new UsuariosCtl(_configuration);

        }

        [HttpGet("Get")]
        public IActionResult Get(Usuarios usuarios) {
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

            return Ok(_usuariosCtl.ObtenerTodos(usuarios));
            
        } 

        [HttpPost("Crear")]
        public IActionResult CrearUsuario(Usuarios usuarios)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _usuariosCtl.Crear(usuarios);
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
        public IActionResult ActualizarUsuario(Usuarios usuarios)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _usuariosCtl.Actualizar(usuarios);
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
        public IActionResult EliminarUsuario(Usuarios usuarios)
        {
            RespuestaDto respuesta;
            try
            {
                // valido la información
                respuesta = _usuariosCtl.Eliminar(usuarios);
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
