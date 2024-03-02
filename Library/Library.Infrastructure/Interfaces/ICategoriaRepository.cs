using Library.Domain.Entities.Usuario_y_categoria;

namespace Library.Infrastructure.Interfaces
{
    public interface ICategoriaRepository
    {
        void Create(Categoria categoria);
        void Update(Categoria categoria);
        void Remove(Categoria categoria);
        List<Categoria> GetCategorias();
        Categoria GetCategoria(int IdCategoria);
    }
}
