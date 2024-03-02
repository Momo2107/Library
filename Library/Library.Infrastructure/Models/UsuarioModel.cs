
namespace Library.Infrastructure.Models
{
    internal class UsuarioModel
    {
        public int idUsuario { get; set; }
        public string? nombreApellidos { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public bool esActivo { get; set; }
    }
}
