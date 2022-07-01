namespace Comun
{
    public class Movimiento
    {
        public int? Id { get; set; }
        public DateTime? Fechahora { get; set; }
        public int IdTipomovimiento { get; set; }
        public string? Observaciones { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdBodega { get; set; }
        public double? Cantidad { get; set; }
    }
}