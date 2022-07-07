namespace Comun
{
    public class Usuarios
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nombre {get; set; }
        public DateTime? Ultimologin { get; set; }
        public State? Estado { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public DateTime? Fechamodificacion { get; set; }
    }
}