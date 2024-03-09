
using Library.Domain.Entities.Usuario_y_categoria;
using Library.Domain.Repository;
using Library.Infrastructure.Context;
using Library.Infrastructure.Core;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly BibliotecaContext context;
        private readonly ILogger<UsuarioRepository> logger;

        public UsuarioRepository(BibliotecaContext context, ILogger<UsuarioRepository> logger) : base(context) 
        {
            this.context = context;
            this.logger = logger;
        }

        public override bool Exists(Func<Usuario, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<Usuario> FindAll(Func<Usuario, bool> filter)
        {
            return base.FindAll(filter);
        }

        public override void Remove(Usuario entity)
        {
            try
            {
                Usuario usuarioToRemove = this.GetEntity(entity.idUsuario);

                if (usuarioToRemove is null)
                    throw new UsuarioException("El usuario no existe.");

                usuarioToRemove.esActivo = false;

                this.context.Usuario.Update(usuarioToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("El usuario ha sido eliminado {0}", ex.ToString());
            }
        }

        public override void Save(Usuario entity)
        {
            try
            {
                if (context.Usuario.Any(usuario => usuario.nombreApellidos == entity.nombreApellidos))
                    throw new UsuarioException("El usuario ya ha sido registrada.");

                this.context.Usuario.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error salvando el usuario. {0}", ex.ToString());

            }
        }

        public override void Update(Usuario entity)
        {
            try
            {
                var usuarioToUpdate = this.GetEntity(entity.idUsuario);

                usuarioToUpdate.nombreApellidos = entity.nombreApellidos;
                usuarioToUpdate.esActivo = entity.esActivo;

                this.context.Usuario.Update(usuarioToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando el usuario. {0}", ex.ToString());
            }
        }

        public override List<Usuario> GetEntities()
        {
            return base.GetEntities().Where(usuario => usuario.esActivo).ToList();
        }

        Usuario IBaseRepository<Usuario>.GetEntity(int id)
        {
            return base.GetEntity(id);
        }
    }
}

