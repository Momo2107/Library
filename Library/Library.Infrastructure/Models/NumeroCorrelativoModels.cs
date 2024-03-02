

namespace Library.Infrastructure.Models
{
    public class NumeroCorrelativoModels
    {
        public int IdNumeroCorrelativo {  get; set; }
        public string? Prefijo {  get; set; }
        public string? Tipo { get; set;}
        public int UltimoNumero { get;}
        public DateTime FechaRegistro {  get; set; }

    }
}
