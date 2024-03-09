using Library.Api.Dtos.Categoria;

namespace Library.Api.Models
{
    public class CategoriaGetModel
    {
        public int Idcategoria { get; set; }
        public string? descripcion { get; set; }
        public bool estado { get; set; }
        public DateTime? fechaCreacion { get; set; }
    }
}
