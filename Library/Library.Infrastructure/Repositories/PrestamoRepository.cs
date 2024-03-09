

using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Library.Infrastructure.Core;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;
using Library.Infrastructure.Models;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Repositories
{
    public class PrestamoRepository : BaseRepository<Prestamo>, IPrestamoRepository
    {
        private readonly DBBibliotecaContext context;
        private readonly ILogger<PrestamoRepository> logger;

        public PrestamoRepository(DBBibliotecaContext context, ILogger<PrestamoRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override List<Prestamo> GetEntities()
        {
            return base.GetEntities().Where(pre => pre.EstadoEntregado == false).ToList();
        }

        public override void Update(Prestamo entity)
        {
            try
            {
                var prestamoToUpdate = this.GetEntity(entity.IdPrestamo);

                prestamoToUpdate.IdLector = entity.IdLector;
                prestamoToUpdate.IdLibro = entity.IdLibro;
                prestamoToUpdate.IdEstadoPrestamo = entity.IdEstadoPrestamo;
                prestamoToUpdate.FechaDevolucion = entity.FechaDevolucion;

                this.context.Prestamos.Update(prestamoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el prestamo", ex.ToString());
            }
        }

        public override void Save(Prestamo entity)
        {
            try
            {
                if (context.Prestamos.Any(pre => pre.IdLector == entity.IdLector))
                    throw new PrestamoException("El lector ya posee un prestamo en curso");

                this.context.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error guardando el prestamo", ex.ToString());
            }
        }

        public List<PrestamoModel> GetPrestamoByLector(int IdLector)
        {
            List<PrestamoModel> prestamos = new List<PrestamoModel>();
            //Crear entidades
            try
            {
                prestamos = (from pre in this.context.Prestamos
                             join le in this.context.Lector on pre.IdLector equals le.IdLector
                             where pre.IdLector == IdLector
                            select new PrestamoModel()
                            {
                                IdPrestamo = pre.IdPrestamo,
                                IdLector = IdLector
                            }).ToList();
                return prestamos;
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el lector", ex.ToString());
            }
        }

    }
}
