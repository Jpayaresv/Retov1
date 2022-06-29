using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Interfaz
{
    interface IGenericoModelo<T, Y>
    {
        public T ObtenerUnicoPorLlave(T parameter);
        public IEnumerable<T> ObtenerTodos(string condicion, string ordenamiento, int? limit);
        public bool Actualizar(T input);
        public bool Crear(T input);
    }
}
