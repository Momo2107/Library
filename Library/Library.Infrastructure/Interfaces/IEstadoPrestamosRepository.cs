


using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;

namespace Library.Infrastructure.Interfaces
{
    public interface IEstadoPrestamosRepository
    {
        void Create(EstadoPrestamo estadoPrestamos);
        void Update(EstadoPrestamo estadoPrestamos);
        void Remove(EstadoPrestamo estadoPrestamos);
        List<EstadoPrestamo> GetEstadoPrestamos();
        EstadoPrestamo GetEstadoPrestamos(int IdEstadoPrestamo);
    }
}
