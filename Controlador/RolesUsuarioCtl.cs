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
    public class RolesUsuarioCtl : ClaseBase, IGenericoControlador<RolesUsuario>
    {
        private readonly IConfiguration _configuration;

        public  RolesUsuarioCtl(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public RespuestaDto Crear(RolesUsuario obj)
        {

            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new RolesUsuarioMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("usuarios", "username", "username = '" + obj.Username + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("roles", "id", "id = '" + obj.IdRol + "'");

            if (!existeObjeto || !existeObjeto1)
            {
                response.AgregarInformacion(Informaciones._227);
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

        public RespuestaDto Actualizar(RolesUsuario obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new RolesUsuarioMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("usuarios", "username", "username = '" + obj.Username + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("roles", "id", "id = '" + obj.IdRol + "'");

            if (!existeObjeto || !existeObjeto1)
            {
                response.AgregarInformacion(Informaciones._227);
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

        public RespuestaDto Eliminar(RolesUsuario obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new RolesUsuarioMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("usuarios", "username", "username = '" + obj.Username + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("roles", "id", "id = '" + obj.IdRol + "'");
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

        public IEnumerable<RolesUsuario> ObtenerTodos(RolesUsuario parameters)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new RolesUsuarioMdl() { ObjConn = Context };
            var condicion = "";
            if(parameters.Username!= null ) {
                condicion = " and Username='" + parameters.Username + "'";
            }

            return _modelo.ObtenerTodos(condicion, string.Empty, null);
        }

        public RolesUsuario ObtenerUnicoPorLlave(RolesUsuario parameter)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new RolesUsuarioMdl() { ObjConn = Context };
            return _modelo.ObtenerUnicoPorLlave(parameter);
        }
    }
}
