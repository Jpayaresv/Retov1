using Comun;
using Controlador.Interfaces;
using Microsoft.Extensions.Configuration;
using Modelo;
using Modelo.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ArticulosCtl :  ClaseBase, IGenericoControlador<Articulos>
    {
        private readonly IConfiguration _configuration;

        public  ArticulosCtl(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public RespuestaDto Crear(Articulos obj)
        {

            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new ArticulosMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("categorias", "id", "id = '" + obj.IdCategoria + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.Id + "'");
            var existeCodigo = _modelo.ExistenRegistros("articulos", "codigo", "codigo = '" + obj.Codigo + "'");

            if(existeObjeto1)
            {
                response.AgregarInformacion(Informaciones._223);
            } else if (!existeObjeto)
            {
                response.AgregarInformacion(Informaciones._227);
            }else if(existeCodigo)
            {
                response.AgregarInformacion(Informaciones._228);
            } else{

                if (_modelo.Crear(obj))
                    response.AgregarCompletado(Completados._101);
                else
                    response.AgregarInformacion(Informaciones._210);
            }
            return response;
        }

        public RespuestaDto Actualizar(Articulos obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new ArticulosMdl() { ObjConn = Context };
            var existeObjeto1 = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.Id + "'");
            var existeObjeto = _modelo.ExistenRegistros("categorias", "id", "id = '" + obj.IdCategoria + "'");
            var existeCodigo = _modelo.ExistenRegistros("articulos", "codigo", "codigo = '" + obj.Codigo + "'");
                      
            if (!existeObjeto1)
            {
                response.AgregarInformacion(Informaciones._202);
            } else if (!existeObjeto)
            {
                response.AgregarInformacion(Informaciones._227);
            }  else if(existeCodigo)
            {
                response.AgregarInformacion(Informaciones._228);
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

        public RespuestaDto Eliminar(Articulos obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new ArticulosMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.Id + "'");
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

        public IEnumerable<Articulos> ObtenerTodos(Articulos parameters)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new ArticulosMdl() { ObjConn = Context };
            var condicion = "";
            if(parameters.Id!= null ) {
                condicion = " and id='" + parameters.Id + "'";
            }

            return _modelo.ObtenerTodos(condicion, string.Empty, null);
        }

        public Articulos ObtenerUnicoPorLlave(Articulos parameter)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new ArticulosMdl() { ObjConn = Context };
            return _modelo.ObtenerUnicoPorLlave(parameter);
        }
    }
}
