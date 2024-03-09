namespace Library.Api.Models
{
    public class UsuarioGetModel
    {
        public int IdUsuario { get; set; }
        public string? NombreApellidos { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public bool EsActivo { get; set; }
        public DateTime? fechaCreacion { get; set; }

    }
}
