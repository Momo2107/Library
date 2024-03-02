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
            try
            {
                if (context.Libros.Any(li => li.Titulo == libro.Titulo))
                    throw new Exception("el titulo ya ha sido registrado.");

                this.context.Libros.Add(libro);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                var libroToRemove = this.GetLibro(libro.IdLibro);

                libroToRemove.Estado = false;

                this.context.Libros.Update(libroToRemove);
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
                var libroToUpdate = this.GetLibro(libro.IdLibro);

                libroToUpdate.Ejemplares = libro.Ejemplares;
                libroToUpdate.Ubicacion = libro.Ubicacion;
                libroToUpdate.Autor = libro.Autor;
                libroToUpdate.Editorial = libro.Editorial;
                libroToUpdate.Portada = libro.Portada;
                libroToUpdate.Titulo = libro.Titulo;

                this.context.Libros.Update(libroToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
