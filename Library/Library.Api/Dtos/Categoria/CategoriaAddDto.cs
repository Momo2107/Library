using System.ComponentModel.DataAnnotations;

namespace Library.Api.Dtos.Categoria
{
    public class CategoriaAddDto : DtoBase
    {
        public string? descripcion { get; set; }
        public bool estado { get; set; }
    }
}
