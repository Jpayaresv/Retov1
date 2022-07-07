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
    public class BodegasCtl : ClaseBase, IGenericoControlador<Bodegas>
    {
        private readonly IConfiguration _configuration;

        public  BodegasCtl(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public RespuestaDto Actualizar(Bodegas obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new BodegasMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.Id + "'");
            var existeCodigo = _modelo.ExistenRegistros("bodegas", "codigo", "codigo = '" + obj.Codigo + "'");
            var ExisteCodigoActualizar = _modelo.ExisteCodigoActualizar("bodegas", "codigo", "codigo = '" + obj.Codigo + "'", "codigo <> ( Select codigo from public.bodegas Where id = '" + obj.Id + "'"  + " )");

            if (!existeObjeto)
            {
                response.AgregarInformacion(Informaciones._202);
            }else if(ExisteCodigoActualizar) {
                response.AgregarInformacion(Informaciones._229);
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

        public RespuestaDto Crear(Bodegas obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new BodegasMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.Id + "'");
            var existeCodigo = _modelo.ExistenRegistros("bodegas", "codigo", "codigo = '" + obj.Codigo + "'");
            
            if (existeObjeto)
            {
                response.AgregarInformacion(Informaciones._223);
            }else if(existeCodigo) {
                response.AgregarInformacion(Informaciones._229);
            }else{
                if (_modelo.Crear(obj))
                    response.AgregarCompletado(Completados._101);
                else
                    response.AgregarInformacion(Informaciones._210);
            }
            return response;
        }

        public RespuestaDto Eliminar(Bodegas obj)
        {
            var response = new RespuestaDto();
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new BodegasMdl() { ObjConn = Context };
            var existeObjeto = _modelo.ExistenRegistros("bodegas", "id", "id = '" + obj.Id + "'");
            
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

        public IEnumerable<Bodegas> ObtenerTodos(Bodegas parameters)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new BodegasMdl() { ObjConn = Context };
            var condicion = "";
            if(parameters.Id!= null ) {
                condicion = " and id='" + parameters.Id + "'";
            }

            return _modelo.ObtenerTodos(condicion, string.Empty, null);
        }

        public Bodegas ObtenerUnicoPorLlave(Bodegas parameter)
        {
            using var Context = new Modelo.Proveedor.Conexion(_configuration["ConnectionStrings:defaultConnection"], _configuration["ConnectionStrings:providerName"]).GetOpenConnection();
            var _modelo = new BodegasMdl() { ObjConn = Context };
            return _modelo.ObtenerUnicoPorLlave(parameter);
        }
    }
}     