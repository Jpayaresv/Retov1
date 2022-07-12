using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class MovimientoMdl : Conexion, IGenericoModelo<Movimiento, int>
    {
        public bool Actualizar(Movimiento input)
        {
            sQuery = "UPDATE public.movimiento SET " +
                     "fechahora = @fechahora,"+
                     "idtipomovimiento = @idtipomovimiento,"+
                     "observaciones = @observaciones,"+
                     "idarticulo = @idarticulo,"+
                     "idbodega = @idbodega,"+
                     "cantidad = @cantidad,"+
                     "estado = @estado "+
                     "WHERE id = @id";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Movimiento input)
        {
            sQuery = "INSERT INTO public.movimiento(id, fechahora, idtipomovimiento, observaciones, idarticulo, idbodega, cantidad, estado) "+
                     "VALUES (@(Select Max(id+1) from public.movimiento), now(), @idtipomovimiento, @observaciones, @idarticulo, @idbodega, @cantidad, @estado)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Movimiento> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT id, fechahora, idtipomovimiento, observaciones, idarticulo, idbodega, cantidad, estado "+
	                " FROM public.movimiento " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Movimiento>(sQuery);
        }

        public Movimiento ObtenerUnicoPorLlave(Movimiento parameter)
        {
            sQuery = "SELECT id, fechahora, idtipomovimiento, observaciones, idarticulo, idbodega, cantidad, estado "+
	                " FROM public.movimiento " +
                     " WHERE 1=1 "+
                     "AND id = @id " ;
            return ObjConn.Query<Movimiento>(sQuery, new { parameter.Id }).FirstOrDefault();         

        }

        public bool Eliminar(Movimiento input)
        {
            sQuery = "DELETE FROM public.movimiento "+
             "WHERE id = @id ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}