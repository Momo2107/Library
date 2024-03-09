namespace Library.Api.Dtos.Usuario
{
    public class UsuarioDtoBase : DtoBase
    {
        public string? NombreApellidos { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public bool EsActivo { get; set; }
    }
}
