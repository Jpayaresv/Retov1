using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class RolesMdl : Conexion, IGenericoModelo<Roles, int>
    {
        public bool Actualizar(Roles input)
        {
            sQuery = "UPDATE public.roles SET " +
                     "nombre = @nombre "+
                     "WHERE id = @id";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Roles input)
        {
            sQuery = "INSERT INTO public.roles(id, nombre) "+
                     "VALUES (@id, @nombre)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Roles> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT id, nombre "+
	                " FROM public.roles " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Roles>(sQuery);
        }

        public Roles ObtenerUnicoPorLlave(Roles parameter)
        {
            sQuery = "SELECT id, nombre "+
	                " FROM public.roles " +
                     " WHERE 1=1 "+
                     "AND id = @id " ;
            return ObjConn.Query<Roles>(sQuery, new { parameter.Id }).FirstOrDefault();         

        }

        public bool Eliminar(Roles input)
        {
            sQuery = "DELETE FROM public.roles "+
             "WHERE id = @id ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}