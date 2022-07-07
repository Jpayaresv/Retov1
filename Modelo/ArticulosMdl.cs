using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class ArticulosMdl : Conexion, IGenericoModelo<Articulos, int>
    {
        public bool Actualizar(Articulos input)
        {
            sQuery = "UPDATE public.articulos SET " +
                     "codigo = @codigo,"+
                     "descripcion = @descripcion,"+
                     "foto = @foto,"+
                     "idcategoria = @idcategoria,"+
                     "preciocompra = @preciocompra,"+
                     "precioventa = @precioventa,"+
                     "fechacreacion = @fechacreacion,"+
                     "fechamodificacion = @fechamodificacion,"+
                     "estado = @estado "+
                     "WHERE id = @id";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Articulos input)
        {

            sQuery = "INSERT INTO public.articulos(id ,codigo, descripcion, foto, idcategoria, preciocompra, precioventa, fechacreacion, fechamodificacion, estado) "+
                     "VALUES ( @(Select Max(id+1) from public.articulos) ,@codigo, @descripcion, @foto, @idcategoria, @preciocompra, @precioventa, @fechacreacion, @fechamodificacion, @estado)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Articulos> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT id, codigo, descripcion, foto, idcategoria, preciocompra, precioventa, fechacreacion, fechamodificacion, estado "+
	                " FROM public.articulos " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Articulos>(sQuery);
        }

        public Articulos ObtenerUnicoPorLlave(Articulos parameter)
        {
            sQuery = "SELECT id, codigo, descripcion, foto, idcategoria, preciocompra, precioventa, fechacreacion, fechamodificacion, estado "+
	                " FROM public.articulos " +
                     " WHERE 1=1 "+
                     "AND id = @id " ;
            return ObjConn.Query<Articulos>(sQuery, new { parameter.Id }).FirstOrDefault();         

        }

        public bool Eliminar(Articulos input)
        {
            sQuery = "DELETE FROM public.articulos "+
             "WHERE id = @id ";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}