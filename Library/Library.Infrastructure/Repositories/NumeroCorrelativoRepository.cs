

using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;
using Library.Infrastructure.Context;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class NumeroCorrelativoRepository : INumeroCorrelativoRepository
    {
        private readonly LibraryContext context;

        public NumeroCorrelativoRepository(LibraryContext context) 
        {
            this.context = context;
        }
        public void Create(NumeroCorrelativo NumeroCorrelativo)
        {
            try
            {
                if (context.NumeroCorrelativo.Any(IdNumeroCorrelativo => IdNumeroCorrelativo.UltimoNumero
                                                == NumeroCorrelativo.UltimoNumero))
                    throw new EstadoPrestamoException("La ultima numeracion esta agregada ya");

                this.context.NumeroCorrelativo.Add(NumeroCorrelativo);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NumeroCorrelativo GetNumeroCorrelativo(int IdNumeroCorrelativo)
        {
            return this.context.NumeroCorrelativo.Find(IdNumeroCorrelativo);
        }

        public List<NumeroCorrelativo> GetNumeroCorrelativos()
        {
            return this.context.NumeroCorrelativo
                               .ToList();
        }

        public void Remove(NumeroCorrelativo NumeroCorrelativo)
        {           
            try
            {
                var NumeroCorrelativoToRemove = this.GetNumeroCorrelativo(NumeroCorrelativo.IdNumeroCorrelativo);
                this.context.NumeroCorrelativo.Update(NumeroCorrelativo);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        public void Update(NumeroCorrelativo NumeroCorrelativo)
        {
            try
            {
                var NumeroCorrelativoToUpdate = this.GetNumeroCorrelativo(NumeroCorrelativo.IdNumeroCorrelativo);

                this.context.NumeroCorrelativo.Update(NumeroCorrelativo);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
