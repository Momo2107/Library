

namespace Library.Infrastructure.Models
{
    public class EstadoPrestamoModels
    {
        public int IdEstadoPrestamo {  get; set; }
        public string? Descripcion { get; set; }
        public bool Estado {  get; set; }
        public DateTime FechaCreacion {  get; set; }
    }
}
