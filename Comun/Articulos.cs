namespace Comun
{
    public class Articulos
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Foto { get; set; }
        public int IdCategoria { get; set; }
        public double? Preciocompra { get; set; }
        public double? Precioventa { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public DateTime? Fechamodificacion { get; set; }
    }
}