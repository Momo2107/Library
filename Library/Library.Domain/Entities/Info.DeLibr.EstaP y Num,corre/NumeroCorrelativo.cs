

using Library.Domain.Core;

namespace Library.Domain.Entities.Info.DeLibr.EstaP_y_Num_corre
{
    internal class NumeroCorrelativo : BaseEntity
    {
        public int? IdNumeroCorrelativo {  get; set; }
        public string? Prefijo { get; set; }
        public string? Tipo { get; set; }
        public int ? UltimoNumero { get; set; }
        public DateTime? FechaRegistro { get; set; }

    }
}
