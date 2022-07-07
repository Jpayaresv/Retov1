namespace Comun
{
    public class TipoMovimiento{ 

        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int? Factor { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public DateTime? Fechamodificacion { get; set; }
        public State? Estado { get; set; }
        
    }
}