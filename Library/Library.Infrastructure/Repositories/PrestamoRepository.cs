

using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly DBBibliotecaContext context;
        public PrestamoRepository(DBBibliotecaContext context)
        {
            this.context = context;
        }
        public void Create(Prestamo prestamo)
        {
            try
            {
                if (context.Prestamos.Any(pre => prestamo.IdLector == prestamo.IdLector))
                    throw new PrestamoException("El lector ya posee un prestamo en curso");

                this.context.Add(prestamo);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Prestamo GetPrestamo(int IdPrestamo)
        {
            return this.context.Prestamos.Find(IdPrestamo);
        }

        public List<Prestamo> GetPrestamos()
        {
            return this.context.Prestamos.ToList();
        }

        public void Remove(Prestamo prestamo)
        {
            try
            {
                var prestamoToRemove = this.GetPrestamo(prestamo.IdPrestamo);

                prestamoToRemove.EstadoEntregado = true;
                prestamoToRemove.EstadoRecibido = prestamo.EstadoRecibido;
                prestamoToRemove.FechaDevolucion = prestamo.FechaDevolucion;

                this.context.Prestamos.Update(prestamoToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Prestamo prestamo)
        {
            try
            {
                var prestamoToUpdate = this.GetPrestamo(prestamo.IdPrestamo);

                prestamoToUpdate.IdLector = prestamo.IdLector;
                prestamoToUpdate.IdLibro = prestamo.IdLibro;
                prestamoToUpdate.IdEstadoPrestamo = prestamo.IdEstadoPrestamo;
                prestamoToUpdate.FechaDevolucion = prestamo.FechaDevolucion;

                this.context.Prestamos.Update(prestamoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
