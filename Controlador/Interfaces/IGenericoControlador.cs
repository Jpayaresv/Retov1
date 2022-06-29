using Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Interfaces
{
    interface IGenericoControlador<T>
    {
        T ObtenerUnicoPorLlave(T parameter);
        IEnumerable<T> ObtenerTodos(T parameters);
        RespuestaDto Actualizar(T obj);
        RespuestaDto Crear(T obj);
    }
}
