using Library.Domain.Entities.Production;
using Library.Infrastructure.Context;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibraryContext context;
        public LibroRepository(LibraryContext context) 
        {
            this.context = context;
        }
        public void Create(Libro libro)
        {
            this.context.Libros.Add(libro);
            this.context.SaveChanges(); 
        }

        public Libro GetLibro(int IdLibro)
        {
            return this.context.Libros.Find(IdLibro);
        }


        public List<Libro> GetLibros()
        {
            return this.context.Libros.ToList();
        }

        public void Remove(Libro libro)
        {
            try
            {

                this.context.Libros.Update(libro);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Libro libro)
        {
            try
            {
                this.context.Libros.Update(libro);
                this.context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
