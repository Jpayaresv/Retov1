using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public enum TipoMensajeRespuesta
    {
        success = 1,
        info = 2,
        warning = 3,
        error = 4
    }

    public class Alertas
    {
        /// <summary>
        /// Usuario no se encuentra Activo
        /// </summary>
        public static RespuestaDto _301 { get { return new RespuestaDto("301", "Usuario no se encuentra Activo", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// Usuario no tiene Rol asignado
        /// </summary>
        public static RespuestaDto _302 { get { return new RespuestaDto("302", "Usuario no tiene Rol asignado", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// No se han definido los valores
        /// </summary>
        public static RespuestaDto _303 { get { return new RespuestaDto("303", "No se han definido los valores", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// Usuario no identificado
        /// </summary>
        public static RespuestaDto _304 { get { return new RespuestaDto("304", "Usuario no identificado", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// Usuario no tiene permiso para acceder a este módulo
        /// </summary>
        public static RespuestaDto _305 { get { return new RespuestaDto("305", "Usuario no tiene permiso para acceder a este módulo", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// No se han ingresado todos los valores
        /// </summary>
        public static RespuestaDto _306 { get { return new RespuestaDto("306", "No se han ingresado todos los valores", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// No se ingresó el archivo
        /// </summary>
        public static RespuestaDto _307 { get { return new RespuestaDto("307", "No se ingresó el archivo", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// El programa tarifario no pertenece a la plaza
        /// </summary>
        public static RespuestaDto _308 { get { return new RespuestaDto("308", "El programa tarifario no pertenece a la plaza", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// Fecha final se puede ser menor o igual que la inicial
        /// </summary>
        public static RespuestaDto _309 { get { return new RespuestaDto("309", "Fecha final se puede ser menor o igual que la inicial", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// IP no tiene el formato correcto
        /// </summary>
        public static RespuestaDto _310 { get { return new RespuestaDto("310", "IP no tiene el formato correcto", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// Sesión NO puede ser liquidada ó YA se liquidó
        /// </summary>
        public static RespuestaDto _311 { get { return new RespuestaDto("311", "Sesión NO puede ser liquidada ó YA se liquidó", TipoMensajeRespuesta.warning); } }
        /// <summary>
        /// Sesión NO puede ser liquidada.Transacciones Incompletas
        /// </summary>
        public static RespuestaDto _312 { get { return new RespuestaDto("312", "Sesión NO puede ser liquidada.Transacciones Incompletas", TipoMensajeRespuesta.warning); } }

    }

    public class Completados
    {
        /// <summary>
        /// Registro creado Correctamente
        /// </summary>
        public static RespuestaDto _101 { get { return new RespuestaDto("101", "Registro creado Correctamente", TipoMensajeRespuesta.success); } }
        /// <summary>
        /// Registro actualizado Correctamente
        /// </summary>
        public static RespuestaDto _102 { get { return new RespuestaDto("102", "Registro actualizado Correctamente", TipoMensajeRespuesta.success); } }
        /// <summary>
        /// Registros procesados Correctamente
        /// </summary>
        public static RespuestaDto _103 { get { return new RespuestaDto("103", "Registros procesados Correctamente", TipoMensajeRespuesta.success); } }
        public static RespuestaDto _104 { get { return new RespuestaDto("104", "Registro eliminado Correctamente", TipoMensajeRespuesta.success); } }

    }

    public class Errores
    {
        /// <summary>
        /// Datos invalidos. Verifique e intente nuevamente
        /// </summary>
        public static RespuestaDto _401 { get { return new RespuestaDto("401", "Datos invalidos. Verifique e intente nuevamente", TipoMensajeRespuesta.error); } }
        /// <summary>
        /// Usuario no existe
        /// </summary>
        public static RespuestaDto _402 { get { return new RespuestaDto("402", "Usuario no existe", TipoMensajeRespuesta.error); } }
        /// <summary>
        /// No se identifica el nivel del sistema
        /// </summary>
        public static RespuestaDto _403 { get { return new RespuestaDto("403", "No se identifica el nivel del sistema", TipoMensajeRespuesta.error); } }
        /// <summary>
        /// Configuración de sistema no Encontrada
        /// </summary>
        public static RespuestaDto _404 { get { return new RespuestaDto("404", "Configuración de sistema no Encontrada", TipoMensajeRespuesta.error); } }
        /// <summary>
        /// Parametros incompletos
        /// </summary>
        public static RespuestaDto _405 { get { return new RespuestaDto("405", "Parametros incompletos", TipoMensajeRespuesta.error); } }

    }

    public class Informaciones
    {
        /// <summary>
        /// No existe información para mostrar
        /// </summary>
        public static RespuestaDto _201 { get { return new RespuestaDto("201", "No existe información para mostrar", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// No existe información para actualizar
        /// </summary>
        public static RespuestaDto _202 { get { return new RespuestaDto("202", "No existe información para actualizar", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// No existe definición para este listado
        /// </summary>
        public static RespuestaDto _203 { get { return new RespuestaDto("203", "No existe definición para este listado", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// No fue posible crear el registro
        /// </summary>
        public static RespuestaDto _210 { get { return new RespuestaDto("210", "No fue posible crear el registro", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// No fue posible actualizar el registro
        /// </summary>
        public static RespuestaDto _211 { get { return new RespuestaDto("211", "No fue posible actualizar el registro", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// Ya existe un registro con el mismo codigo
        /// </summary>
        public static RespuestaDto _221 { get { return new RespuestaDto("221", "Ya existe un registro con el mismo codigo", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// Ya existe un registro con la misma IP
        /// </summary>
        public static RespuestaDto _222 { get { return new RespuestaDto("222", "Ya existe un registro con la misma IP", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// Ya existe un registro creado
        /// </summary>
        public static RespuestaDto _223 { get { return new RespuestaDto("223", "Ya existe un registro creado", TipoMensajeRespuesta.info); } }
        /// <summary>
        /// Ya existe una categoria MOTO definida para la estacion
        /// </summary>
        public static RespuestaDto _224 { get { return new RespuestaDto("224", "Ya existe una categoria MOTO definida para la estacion", TipoMensajeRespuesta.info); } }
        public static RespuestaDto _225 { get { return new RespuestaDto("225", "No fue posible eliminar el registro", TipoMensajeRespuesta.info); } }
        public static RespuestaDto _226 { get { return new RespuestaDto("226", "No existe información para eliminar", TipoMensajeRespuesta.info); } }

    }

    public class RespuestaDto
    {

        public RespuestaDto(string codigo, string errorMessage, TipoMensajeRespuesta tipo)
        {
            this.mensaje = errorMessage;
            this.codigomensaje = codigo;
            this.tipomensaje = tipo;
        }

        public RespuestaDto()
        {
            AgregarCompletado("", "");
        }
        public TipoMensajeRespuesta tipomensaje { set; get; }

        public string nombretipomensaje
        {
            get { return Enum.GetName(typeof(TipoMensajeRespuesta), tipomensaje); }
        }
        public string mensaje { get; set; }
        public string codigomensaje { get; set; }

        public void AgregarError(string codigo, string errorMessage)
        {
            this.codigomensaje = codigo;
            this.tipomensaje = TipoMensajeRespuesta.error;
            this.mensaje = errorMessage;
        }
        public void AgregarError(RespuestaDto errorMessage)
        {
            this.mensaje = errorMessage.mensaje;
            this.codigomensaje = errorMessage.codigomensaje;
            this.tipomensaje = errorMessage.tipomensaje;

        }

        public void AgregarInformacion(string codigo, string errorMessage)
        {
            this.codigomensaje = codigo;
            this.tipomensaje = TipoMensajeRespuesta.info;
            this.mensaje = errorMessage;
        }
        public void AgregarInformacion(RespuestaDto infoMessage)
        {
            this.mensaje = infoMessage.mensaje;
            this.codigomensaje = infoMessage.codigomensaje;
            this.tipomensaje = infoMessage.tipomensaje;
        }

        public void AgregarCompletado(string codigo, string errorMessage)
        {
            this.codigomensaje = codigo;
            this.tipomensaje = TipoMensajeRespuesta.success;
            this.mensaje = errorMessage;
        }
        public void AgregarCompletado(RespuestaDto succesMessage)
        {
            this.mensaje = succesMessage.mensaje;
            this.codigomensaje = succesMessage.codigomensaje;
            this.tipomensaje = succesMessage.tipomensaje;
        }

        public void AgregarAlerta(string codigo, string errorMessage)
        {
            this.codigomensaje = codigo;
            this.tipomensaje = TipoMensajeRespuesta.warning;
            this.mensaje = errorMessage;
        }
        public void AgregarAlerta(RespuestaDto alertMessage)
        {
            this.mensaje = alertMessage.mensaje;
            this.codigomensaje = alertMessage.codigomensaje;
            this.tipomensaje = alertMessage.tipomensaje;
        }
    }
}
