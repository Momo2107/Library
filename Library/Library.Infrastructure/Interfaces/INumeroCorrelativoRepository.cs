



using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;

namespace Library.Infrastructure.Interfaces
{
    public interface INumeroCorrelativoRepository
    {
        void Create(NumeroCorrelativo NumeroCorrelativo);
        void Update(NumeroCorrelativo NumeroCorrelativo);
        void Remove(NumeroCorrelativo NumeroCorrelativo);
        List<NumeroCorrelativo> GetNumeroCorrelativos();
        NumeroCorrelativo GetNumeroCorrelativo(int IdNumeroCorrelativo);
    }
}
