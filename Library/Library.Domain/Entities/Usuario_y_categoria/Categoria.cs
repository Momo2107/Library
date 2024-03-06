using Library.Domain.Core;
using System.ComponentModel.DataAnnotations;


namespace Library.Domain.Entities.Usuario_y_categoria
{
    public class Categoria : BaseEntity
    {
        [Key]
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
