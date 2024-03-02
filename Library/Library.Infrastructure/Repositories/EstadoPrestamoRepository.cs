

using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;
using Library.Infrastructure.Context;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class EstadoPrestamoRepository : IEstadoPrestamosRepository

    {
        private readonly LibraryContext context;

        public EstadoPrestamoRepository(LibraryContext context)
        {
            this.context = context;
        }
        public void Create(EstadoPrestamo estadoPrestamos)
        {
            try
            {
                if (context.EstadoPrestamo.Any(IdEstadoPrestamo => IdEstadoPrestamo.Estado 
                                                == true))
                    throw new EstadoPrestamoException("El libro esta prestado ya");
            
                this.context.EstadoPrestamo.Add(estadoPrestamos);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EstadoPrestamo> GetEstadoPrestamos()
        {
            return this.context.EstadoPrestamo.ToList();
        }

        public EstadoPrestamo GetEstadoPrestamos(int IdEstadoPrestamo)
        {
            return this.context.EstadoPrestamo.Find(IdEstadoPrestamo);
        }

        public void Remove(EstadoPrestamo estadoPrestamos)
        {
            try
            {
                var NumeroCorrelativoToRemove = this.GetEstadoPrestamos(estadoPrestamos.IdEstadoPrestamo);
                this.context.EstadoPrestamo.Update(estadoPrestamos);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(EstadoPrestamo estadoPrestamos)
        {
            try
            {
                var NumeroCorrelativoToUpdate = this.GetEstadoPrestamos(estadoPrestamos.IdEstadoPrestamo);

                this.context.EstadoPrestamo.Update(estadoPrestamos);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
