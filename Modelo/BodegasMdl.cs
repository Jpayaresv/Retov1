using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class BodegasMdl : Conexion, IGenericoModelo<Bodegas, int>
    {
        public bool Actualizar(Bodegas input)
        {
            sQuery = "UPDATE public.bodegas SET " +
                     "codigo = @codigo,"+
                     "descripcion = @descripcion,"+
                     "foto = @foto,"+
                     "fechacreacion = @fechacreacion,"+
                     "fechamodificacion = @fechamodificacion "+
                     "WHERE id = @id";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Bodegas input)
        {
            sQuery = "INSERT INTO public.bodegas(id, codigo, descripcion, foto, fechacreacion, fechamodificacion) "+
                     "VALUES (@id, @codigo, @descripcion, @foto, @fechacreacion, @fechamodificacion)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Bodegas> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT id, codigo, descripcion, foto, fechacreacion, fechamodificacion "+
	                " FROM public.bodegas " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Bodegas>(sQuery);
        }

        public Bodegas ObtenerUnicoPorLlave(Bodegas parameter)
        {
            sQuery = "SELECT id, codigo, descripcion, foto, fechacreacion, fechamodificacion "+
	                " FROM public.bodegas " +
                     " WHERE 1=1 "+
                     "AND id = @id " ;
            return ObjConn.Query<Bodegas>(sQuery, new { parameter.Id }).FirstOrDefault();         

        }

        public bool Eliminar(Bodegas input)
        {
            sQuery = "DELETE FROM public.bodegas "+
             "WHERE id = @id ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}