using Library.Domain.Core;


namespace Library.Domain.Entities.Usuario_y_categoria
{
    public class Categoria : BaseEntity
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
