using Library.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities.Usuario_y_categoria
{
    public class Usuario : BaseEntity
    {
        [Key]
        public int idUsuario { get; set; }
        public string? nombreApellidos { get; set; }
        public string? correo { get; set; }
        public string? clave { get; set; }
        public bool esActivo { get; set; }
    }
}
