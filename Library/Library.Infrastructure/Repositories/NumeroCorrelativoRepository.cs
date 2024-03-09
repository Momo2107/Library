

using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;
using Library.Infrastructure.Context;
using Library.Infrastructure.Core;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Repositories
{
    public class NumeroCorrelativoRepository : BaseRepository<NumeroCorrelativo>,INumeroCorrelativoRepository
    {
        private readonly LibraryContext context;
        private readonly ILogger<INumeroCorrelativoRepository> logger;

        public NumeroCorrelativoRepository(LibraryContext context,ILogger<INumeroCorrelativoRepository>logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<NumeroCorrelativo> GetEntities()
        {
            return base.GetEntities().ToList();
        }
        public override void Update(NumeroCorrelativo entity)
        {
            try
            {
                var NumeroCorrelativoToUpdate = this.GetEntity(entity.IdNumeroCorrelativo);

                NumeroCorrelativoToUpdate.Prefijo = entity.Prefijo;
                NumeroCorrelativoToUpdate.Estado = entity.Estado;   
                NumeroCorrelativoToUpdate.UltimoNumero = entity.UltimoNumero;
                NumeroCorrelativoToUpdate.FechaCreacion= entity.FechaCreacion;

                this.context.NumeroCorrelativo.Update(NumeroCorrelativoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error al actualizar el Numero Correlativo", ex.ToString);
            }
        }
        public override void Save(NumeroCorrelativo entity)
        {

            try
            {
                if (context.NumeroCorrelativo.Any(IdNumeroCorrelativo => IdNumeroCorrelativo.UltimoNumero
                                                == entity.UltimoNumero))
                    throw new EstadoPrestamoException("La ultima numeracion esta agregada ya");

                this.context.NumeroCorrelativo.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error creando el Numero Correlativo", ex.ToString);
            }
        }

    }
}
