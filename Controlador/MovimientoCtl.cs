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
    public class MovimientoCtl : ClaseBase, IGenericoControlador<Movimiento>
    {
        private readonly IConfiguration _configuration;

        public  MovimientoCtl(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public RespuestaDto Actualizar(Movimiento obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new MovimientoMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("movimiento", "id", "id = '" + obj.Id + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("tipomovimiento", "id", "id = '" + obj.IdTipomovimiento + "'");
            var existeObjeto2 = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.IdArticulo + "'");
            var existeObjeto3 = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.IdBodega + "'");

            
            if (!existeObjeto || !existeObjeto1 || !existeObjeto2 || !existeObjeto3)
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

        public RespuestaDto Crear(Movimiento obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new MovimientoMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("movimiento", "id", "id = '" + obj.Id + "'");
            var existeObjeto1 = _modelo.ExistenRegistros("tipomovimiento", "id", "id = '" + obj.IdTipomovimiento + "'");
            var existeObjeto2 = _modelo.ExistenRegistros("articulos", "id", "id = '" + obj.IdArticulo + "'");
            var existeObjeto3 = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.IdBodega + "'");

            
            if (existeObjeto || !existeObjeto1 || !existeObjeto2 || !existeObjeto3)
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

        public RespuestaDto Eliminar(Movimiento obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new MovimientoMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("tipomovimiento", "id", "id = '" + obj.Id + "'");
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

        public IEnumerable<Movimiento> ObtenerTodos(Movimiento parameters)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new MovimientoMdl() { ObjConn = Context };
            var condicion = "";
            if(parameters.Id!= null ) {
                condicion = " and id='" + parameters.Id + "'";
            }

            return _modelo.ObtenerTodos(condicion, string.Empty, null);
        }

        public Movimiento ObtenerUnicoPorLlave(Movimiento parameter)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new MovimientoMdl() { ObjConn = Context };
            return _modelo.ObtenerUnicoPorLlave(parameter);
        }
    }
}     