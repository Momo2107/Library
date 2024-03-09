

using Library.Domain.Entities;
using Library.Domain.Repository;
using Library.Infrastructure.Models;

namespace Library.Infrastructure.Interfaces
{
    public interface IPrestamoRepository : IBaseRepository<Prestamo>
    {
        List<PrestamoModel> GetPrestamoByLector(int IdLector);
        //List<PrestamoModel> GetPrestamoByEstado (bool Estado);

    }
}
