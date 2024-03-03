
using Library.Domain.Entities.Usuario_y_categoria;
using Library.Infrastructure.Context;
using Library.Infrastructure.Core;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly BibliotecaContext context;
        private readonly ILogger<CategoriaRepository> logger;
        public CategoriaRepository(BibliotecaContext context, ILogger<CategoriaRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override List<Categoria> GetEntities()
        {
            return base.GetEntities().Where(categoria => !categoria.Estado).ToList();
        }
        public override void Update(Categoria entity)
        {
            try
            {
                var categoriaToUpdate = this.GetEntity(entity.IdCategoria);

                categoriaToUpdate.Descripcion = entity.Descripcion;
                categoriaToUpdate.Estado = entity.Estado;

                this.context.Categoria.Update(categoriaToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando la categoria. {0}", ex.ToString());
            }
        }
        public override void Save(Categoria entity)
        {
            try
            {
                if (context.Categoria.Any(categoria => categoria.Descripcion == entity.Descripcion))
                    throw new UsuarioException("La categoria ya ha sido registrada.");

                this.context.Categoria.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error salvando la categoría. {0}", ex.ToString());

            }

        }

        
    }
}

