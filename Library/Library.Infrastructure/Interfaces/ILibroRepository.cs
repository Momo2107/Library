
using Library.Domain.Entities.Production;

namespace Library.Infrastructure.Interfaces
{
    public interface ILibroRepository
    {
        void Create(Libro libro);
        void Update(Libro libro);
        void Remove(Libro libro);

        List<Libro> GetLibros();
        Libro GetLibro(int idLibro);

    }

}
