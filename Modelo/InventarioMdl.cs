using Comun;
using Dapper;
using Modelo.Interfaz;
using Modelo.Proveedor;

namespace Modelo
{
    public class InventarioMdl : Conexion, IGenericoModelo<Inventario, int>
    {
        public bool Actualizar(Inventario input)
        {
            sQuery = "UPDATE public.inventario SET " +
                     "saldo = @saldo,"+
                     "fechaultimomovimiento = @fechaultimomovimiento "+
                     "WHERE idarticulo = @idarticulo and idbodega = @idbodega";

            return ObjConn.Execute(sQuery, input) > 0;
        }

        public bool Crear(Inventario input)
        {
            sQuery = "INSERT INTO public.inventario(idarticulo, idbodega, saldo, fechaultimomovimiento) "+
                     "VALUES (@idarticulo, @idbodega, @saldo, @fechaultimomovimiento)"; 
                        
            return ObjConn.Execute(sQuery, input) > 0;
        }

        public IEnumerable<Inventario> ObtenerTodos(string condicion, string ordenamiento, int? limit)
        {
            sQuery = "SELECT idarticulo, idbodega, saldo, fechaultimomovimiento "+
	                " FROM public.inventario " +
                     " WHERE 1=1 " ;
            if(!string.IsNullOrEmpty(condicion)) {
                sQuery += condicion;
            }
            if(!string.IsNullOrEmpty(ordenamiento)) {
                sQuery += ordenamiento;
            }
            if(limit != null) sQuery += " limit " + limit;

            return ObjConn.Query<Inventario>(sQuery);
        }

        public Inventario ObtenerUnicoPorLlave(Inventario parameter)
        {
            sQuery = "SELECT id, descripcion, foto, fechacreacion, fechamodificacion "+
	                " FROM public.categorias " +
                     " WHERE 1=1 "+
                     "AND idArticulo = @idArticulo " ;
            return ObjConn.Query<Inventario>(sQuery, new { parameter.IdArticulo/* , parameter.IdBodega */}).FirstOrDefault();         

        }

        public bool Eliminar(Inventario input)
        {
            sQuery = "DELETE FROM public.inventario "+
             "WHERE idarticulo = @idarticulo and idbodega = @idbodega";       

            return ObjConn.Execute(sQuery, input) > 0;
        }

    }
}