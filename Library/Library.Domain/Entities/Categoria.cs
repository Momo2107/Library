using Library.Domain.Core;


namespace Library.Domain.Entities
{
    internal class Categoria : BaseEntity
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
