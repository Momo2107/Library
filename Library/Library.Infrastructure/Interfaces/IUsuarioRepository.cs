using Library.Domain.Entities.Usuario_y_categoria;

namespace Library.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(int idUsuario);
    }
}
