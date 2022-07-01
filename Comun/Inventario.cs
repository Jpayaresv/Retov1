namespace Comun
{
    public class Inventario
    {
        public int? IdArticulo { get; set; }
        public int? IdBodega { get; set; }
        public double? Saldo { get; set; }
        public DateTime? Fechaultimomovimiento { get; set; }
    }
}