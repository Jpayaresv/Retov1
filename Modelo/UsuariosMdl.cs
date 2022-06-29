using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuariosMdl : Conexion, IGenericoModelo<Usuarios, int>
    {
        public bool Actualizar(Usuarios input)
        {
            sQuery = "UPDATE usuarios SET " +
                     "username = @username," +
                     "password = @password," +
                     "ultimologin = @ultimologin,"+
                     "nombre = @nombre," +
                     "estado = @estado," +
                     "fechacreacion = @fechacreacion,"+
                     "fechamodificacion = @fechamodificacion " +
                     "WHERE username = @username";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Usuarios input)
        {
            sQuery = "INSERT INTO public.usuarios(username, password, ultimologin, nombre, estado, fechacreacion, fechamodificacion)" +
	                 "VALUES (@username, @password,@ultimologin, @nombre, @estado, @fechacreacion, @fechamodificacion)";
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Usuarios> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {

            sQuery = "SELECT username, password, ultimologin, nombre, estado, fechacreacion, fechamodificacion " +
                " FROM usuarios " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Usuarios>(sQuery);
        }

        public Usuarios ObtenerUnicoPorLlave(Usuarios parameter)
        {
            sQuery = "SELECT username, password, ultimologin, nombre, estado, fechacreacion, fechamodificacion " +
                " FROM usuarios " +
                     " WHERE 1=1 " +
                     "   AND username = @Username ";
            return ObjConn.Query<Usuarios>(sQuery, new { parameter.Username }).FirstOrDefault();
        }
    }
}
