
using Library.Domain.Core;

namespace Library.Domain.Entities
{
    public class Lector : BaseEntity 
    {
        public int? IdLector { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
    }
}
