

using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;
using Library.Infrastructure.Context;
using Library.Infrastructure.Core;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Repositories
{
    public class EstadoPrestamoRepository : BaseRepository<EstadoPrestamo>,IEstadoPrestamosRepository

    {
        private readonly LibraryContext context;
        private readonly ILogger<EstadoPrestamoRepository> logger;

        public EstadoPrestamoRepository(LibraryContext context,ILogger<EstadoPrestamoRepository>logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<EstadoPrestamo> GetEntities()
        {
            return base.GetEntities().ToList();
        }
        public override void Update(EstadoPrestamo entity)
        {
            try
            {
                var EstadoPrestamosToUpdate = this.GetEntity(entity.IdEstadoPrestamo);

                EstadoPrestamosToUpdate.Estado = entity.Estado;
                EstadoPrestamosToUpdate.Descripcion = entity.Descripcion;
                EstadoPrestamosToUpdate.FechaCreacion = entity.FechaCreacion;

                this.context.EstadoPrestamo.Update(EstadoPrestamosToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error al actualizar el Estado prestamo", ex.ToString);
            }
        }
        public override void Save(EstadoPrestamo entity)
        {
            try
            {
                if (context.EstadoPrestamo.Any(IdEstadoPrestamo => IdEstadoPrestamo.Estado
                                                == true))
                    throw new EstadoPrestamoException("El libro esta prestado ya");

                this.context.EstadoPrestamo.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando el EstadoPrestamo ", ex.ToString());
            }
        }
    }
}
