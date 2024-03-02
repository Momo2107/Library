

using Library.Domain.Core;

namespace Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo
{
    public class EstadoPrestamo : BaseEntity 
    {
        public int IdEstadoPrestamo { get; set; }
        public string? Descripcion { get; set; }

    }
}
