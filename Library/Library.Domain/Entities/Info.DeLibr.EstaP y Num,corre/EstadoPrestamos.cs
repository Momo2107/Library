

using Library.Domain.Core;

namespace Library.Domain.Entities
{
    public class EstadoPrestamos : BaseEntity
    {
        public int? IdEstadoPrestamo { get; set; }
        public string? Descripcion { get; set; }

    }
}
