
using Library.Domain.Entities.Usuario_y_categoria;
using Library.Infrastructure.Context;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.Interfaces;

namespace Library.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly BibliotecaContext context;
        public CategoriaRepository(BibliotecaContext context)
        {
            this.context = context;
        }
        public void Create(Categoria categoria)
        {
            try
            {
                if (context.Categoria.Any(ca => ca.Descripcion == categoria.Descripcion))
                    throw new UsuarioException("La Descripcion ya ha sido registrada.");

                this.context.Categoria.Add(categoria);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria GetCategoria(int IdCategoria)
        {
            return this.context.Categoria.Find(IdCategoria);
        }

        public List<Categoria> GetCategorias()
        {
            return this.context.Categoria.Where(ca => ca.Estado == true || ca.Estado == null).ToList();
        }

        public void Remove(Categoria categoria)
        {
            try
            {
                var categoriaToRemoe = this.GetCategoria(categoria.IdCategoria);

                categoriaToRemoe.Estado = false;

                this.context.Categoria.Update(categoriaToRemoe);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Categoria categoria)
        {
            try
            {
                var categoriaToUpdate = this.GetCategoria(categoria.IdCategoria);

                categoriaToUpdate.Descripcion = categoria.Descripcion;
                categoriaToUpdate.Estado = categoria.Estado;

                this.context.Categoria.Update(categoriaToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

