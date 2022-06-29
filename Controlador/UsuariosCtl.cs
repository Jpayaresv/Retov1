using Comun;
using Controlador.Interfaces;
using Microsoft.Extensions.Configuration;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class UsuariosCtl : ClaseBase, IGenericoControlador<Usuarios>
    {
        private readonly IConfiguration _configuration;

        public UsuariosCtl(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public RespuestaDto Crear(Usuarios obj)
        {

            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new UsuariosMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("usuarios", "username", "username = '" + obj.Username + "'");
            if (existeObjeto)
            {
                response.AgregarInformacion(Informaciones._223);
            }
            else
            {
                if (_modelo.Crear(obj))
                    response.AgregarCompletado(Completados._101);
                else
                    response.AgregarInformacion(Informaciones._210);
            }
            return response;
        }

        public RespuestaDto Actualizar(Usuarios obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new UsuariosMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("usuarios", "username", "username = '" + obj.Username + "'");
            if (!existeObjeto)
            {
                response.AgregarInformacion(Informaciones._202);
            }
            else
            {
                if (_modelo.Actualizar(obj))
                    response.AgregarCompletado(Completados._102);
                else
                    response.AgregarInformacion(Informaciones._211);
            }
            return response;
        }

        public RespuestaDto Eliminar(Usuarios obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new UsuariosMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("usuarios", "username", "username = '" + obj.Username + "'");
            if (!existeObjeto)
            {
                response.AgregarInformacion(Informaciones._226);
            }
            else
            {
                if (_modelo.Eliminar(obj))
                    response.AgregarCompletado(Completados._104);
                else
                    response.AgregarInformacion(Informaciones._225);
            }
            return response;
        }

        public IEnumerable<Usuarios> ObtenerTodos(Usuarios parameters)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new UsuariosMdl() { ObjConn = Context };
            var condicion = "";
            if(parameters.Username!="") {
                condicion = " and username='" + parameters.Username + "'";
            }

            return _modelo.ObtenerTodos(condicion, string.Empty, null);
        }

        public Usuarios ObtenerUnicoPorLlave(Usuarios parameter)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new UsuariosMdl() { ObjConn = Context };
            return _modelo.ObtenerUnicoPorLlave(parameter);
        }
    }
}
