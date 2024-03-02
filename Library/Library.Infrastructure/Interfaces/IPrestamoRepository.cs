

using Library.Domain.Entities;

namespace Library.Infrastructure.Interfaces
{
    public interface IPrestamoRepository
    {
        void Create(Prestamo prestamo);
        void Update(Prestamo prestamo);
        void Remove(Prestamo prestamo);
        List<Prestamo> GetPrestamos();
        Prestamo GetPrestamo(int IdPrestamo);


    }
}
