

namespace Library.Infrastructure.Models
{
    public class PrestamoModel
    {
        public int IdPrestamo { get; set; }
        public int IdLector { get; set; }
        public string? Name { get; set; }
        public string? Apellido { get; set; }
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int IdEstadoPrestamo { get; set; }
        public bool? Estado { get; set; }
    }
}
