
using Library.Domain.Entities.Usuario_y_categoria;
using Library.Infrastructure.Context;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaContext context;
        public UsuarioRepository(BibliotecaContext context) 
        {
            this.context = context;
        }
        public void Create(Usuario usuario)
        {
            try
            {
                if (context.Usuario.Any(ca => ca.nombreApellidos == usuario.nombreApellidos))
                    throw new UsuarioException("El usuario se encuentra registrado.");

                this.context.Usuario.Add(usuario);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUsuario(int idUsuario)
        {
            return this.context.Usuario.Find(idUsuario);
        }

        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuario.Where(ca => ca.esActivo).ToList();
        }

        public void Remove(Usuario usuario)
        {
            try
            {
                var usuarioToRemoe = this.GetUsuario(usuario.idUsuario);

                usuarioToRemoe.esActivo = false;

                this.context.Usuario.Update(usuarioToRemoe);
                this.context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }

        public void Update(Usuario usuario)
        {
            try
            {
                var usuarioToUpdate = this.GetUsuario(usuario.idUsuario);

                usuarioToUpdate.nombreApellidos = usuario.nombreApellidos;
                usuarioToUpdate.correo = usuario.correo;
                usuarioToUpdate.clave = usuario.clave;
                usuarioToUpdate.FechaCreacion = usuario.FechaCreacion;

                this.context.Usuario.Update(usuarioToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}

