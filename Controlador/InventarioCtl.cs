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
    public class InventarioCtl : ClaseBase, IGenericoControlador<Inventario>
    {
        private readonly IConfiguration _configuration;

        public  InventarioCtl(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public RespuestaDto Crear(Inventario obj)
        {

            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new InventarioMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.IdArticulo + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.IdBodega + "'");
            var existeObjeto2 = _modelo.ExistenRegistros("inventario", "idArticulo", "idArticulo = '" + obj.IdArticulo + "'");
            var existeObjeto3 = _modelo.ExistenRegistros("inventario", "idBodega", "idBodega = '" + obj.IdBodega + "'");

            
            if(existeObjeto2 || existeObjeto3){
                response.AgregarInformacion(Informaciones._223);
            }
            else if (!existeObjeto || !existeObjeto1)
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

        public RespuestaDto Actualizar(Inventario obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new InventarioMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.IdArticulo + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.IdBodega + "'");
            var existeObjeto2 = _modelo.ExistenRegistros("inventario", "idArticulo", "idArticulo = '" + obj.IdArticulo + "'");
            var existeObjeto3 = _modelo.ExistenRegistros("inventario", "idBodega", "idBodega = '" + obj.IdBodega + "'");

            
            if(!existeObjeto2 || !existeObjeto3){
                response.AgregarInformacion(Informaciones._202);
            }
            else if (!existeObjeto || !existeObjeto1)
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

        public RespuestaDto Eliminar(Inventario obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new InventarioMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("inventario", "idArticulo", "idArticulo = '" + obj.IdArticulo + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("inventario", "idBodega", "idBodega = '" + obj.IdBodega + "'");

            if (!existeObjeto || !existeObjeto1)
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

        public IEnumerable<Inventario> ObtenerTodos(Inventario parameters)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new InventarioMdl() { ObjConn = Context };
            var condicion = "";

            if(parameters.IdArticulo!= null  && parameters.IdBodega!= null ) {
                condicion = " and idarticulo= '" + parameters.IdArticulo  + "'" + " and idbodega= '" + parameters.IdBodega + "'";
            }

            return _modelo.ObtenerTodos(condicion, string.Empty, null);
        }

        public Inventario ObtenerUnicoPorLlave(Inventario parameter)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new InventarioMdl() { ObjConn = Context };
            return _modelo.ObtenerUnicoPorLlave(parameter);
        }
    }
}
