using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class RolesUsuarioMdl : Conexion, IGenericoModelo<RolesUsuario, int>
    {
        public bool Actualizar(RolesUsuario input)
        {
            sQuery = "UPDATE public.rolesusuario SET " +
                     "username = @username "+
                     "idrol = @idrol "+
                     "WHERE username = @username AND idrol = @idrol";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(RolesUsuario input)
        {
            sQuery = "INSERT INTO public.rolesusuario(username, idrol) "+
                     "VALUES (@username, @idrol)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<RolesUsuario> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT username, idrol "+
	                " FROM public.rolesusuario " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<RolesUsuario>(sQuery);
        }

        public RolesUsuario ObtenerUnicoPorLlave(RolesUsuario parameter)
        {
            sQuery = "SELECT username, idrol "+
	                " FROM public.rolesusuario " +
                     " WHERE 1=1 "+
                     "AND username = @username " ;
            return ObjConn.Query<RolesUsuario>(sQuery, new { parameter.Username }).FirstOrDefault();         

        }

        public bool Eliminar(RolesUsuario input)
        {
            sQuery = "DELETE FROM public.rolesusuario "+
             "WHERE username = @username ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}