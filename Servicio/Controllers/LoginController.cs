using Comun;
using Controlador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
//using System.Web.Providers.Entities;

namespace Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        private readonly UsuariosCtl _usuariosCtl;
        public LoginController(IConfiguration configuration, ILogger<LoginController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _usuariosCtl = new UsuariosCtl(_configuration);
        }

/*         [HttpGet, Authorize]
        public ActionResult<string> Get()
        {
            var userName = 
        }
         */
        [HttpPost]
        public IActionResult Login(Usuarios request)
        {
            RespuestaDto respuesta;

            if(request.Username == null || request.Password == null)
            {
                return BadRequest();
            }

            var usuariodata = _usuariosCtl.ObtenerUnicoPorLlave(new Usuarios { Username = request.Username });
            if (usuariodata == null) return NotFound();

            if (usuariodata.Password != request.Password) {
                respuesta = new RespuestaDto();
                respuesta.AgregarError("1000", "Password no coincide");
                return BadRequest(respuesta);
            }

            if (usuariodata.Estado == State.Inactivo){
                respuesta = new RespuestaDto();
                respuesta.AgregarError("1001", "No es posible acceder, debido a que el usuario se encuentra inactivo.");
                return Unauthorized(respuesta);
                
            }

            string token = CreateToken(usuariodata);

            return Ok(new { data = usuariodata, codigo = "Ok", mensaje = "Todo Ok", token = token });
        }

        private string CreateToken(Usuarios usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
