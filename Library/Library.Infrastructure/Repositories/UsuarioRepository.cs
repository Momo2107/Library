
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
            base.Remove(entity);
        }

        public override void Save(Usuario entity)
        {
            base.Save(entity);
        }

        public override void Update(Usuario entity)
        {
            base.Update(entity);
        }

        List<Usuario> IBaseRepository<Usuario>.GetEntities()
        {
            return base.GetEntities();
        }

        Usuario IBaseRepository<Usuario>.GetEntity(int id)
        {
            return base.GetEntity(id);
        }
    }
}

