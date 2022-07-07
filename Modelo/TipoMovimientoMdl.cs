using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class TipoMovimientoMdl : Conexion, IGenericoModelo<TipoMovimiento, int>
    {
        public bool Actualizar(TipoMovimiento input)
        {
            sQuery = "UPDATE public.tipomovimiento SET " +
                     "codigo = @codigo,"+
                     "descripcion = @descripcion,"+
                     "factor = @factor,"+
                     "fechacreacion = @fechacreacion,"+
                     "fechamodificacion = @fechamodificacion,"+
                     "estado = @estado "+
                     "WHERE id = @id";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(TipoMovimiento input)
        {
            sQuery = "INSERT INTO public.tipomovimiento(id, codigo, descripcion, factor, fechacreacion, fechamodificacion, estado) "+
                     "VALUES (@id, @codigo, @descripcion, @factor, @fechacreacion, @fechamodificacion, @estado)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<TipoMovimiento> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT id, codigo, descripcion, factor, fechacreacion, fechamodificacion, estado "+
	                " FROM public.tipomovimiento " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<TipoMovimiento>(sQuery);
        }

        public TipoMovimiento ObtenerUnicoPorLlave(TipoMovimiento parameter)
        {
            sQuery = "SELECT id, codigo, descripcion, factor, fechacreacion, fechamodificacion, estado "+
	                " FROM public.tipomovimiento " +
                     " WHERE 1=1 "+
                     "AND id = @id " ;
            return ObjConn.Query<TipoMovimiento>(sQuery, new { parameter.Id }).FirstOrDefault();         

        }

        public bool Eliminar(TipoMovimiento input)
        {
            sQuery = "DELETE FROM public.tipomovimiento "+
             "WHERE id = @id ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}