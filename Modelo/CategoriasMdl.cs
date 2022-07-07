using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class CategoriasMdl : Conexion, IGenericoModelo<Categorias, int>
    {
        public bool Actualizar(Categorias input)
        {
            sQuery = "UPDATE public.categorias SET " +
                     "descripcion = @descripcion,"+
                     "foto = @foto,"+
                     "fechacreacion = @fechacreacion,"+
                     "fechamodificacion = @fechamodificacion,"+
                     "estado = @estado "+
                     "WHERE id = @id";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Categorias input)
        {
            sQuery = "INSERT INTO public.categorias(id, descripcion, foto, fechacreacion, fechamodificacion, estado) "+
                     "VALUES (@id, @descripcion, @foto, @fechacreacion, @fechamodificacion, @estado)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Categorias> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT id, descripcion, foto, fechacreacion, fechamodificacion, estado "+
	                " FROM public.categorias " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Categorias>(sQuery);
        }

        public Categorias ObtenerUnicoPorLlave(Categorias parameter)
        {
            sQuery = "SELECT id, descripcion, foto, fechacreacion, fechamodificacion, estado "+
	                " FROM public.categorias " +
                     " WHERE 1=1 "+
                     "AND id = @id " ;
            return ObjConn.Query<Categorias>(sQuery, new { parameter.Id }).FirstOrDefault();         

        }

        public bool Eliminar(Categorias input)
        {
            sQuery = "DELETE FROM public.categorias "+
             "WHERE id = @id ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}