
using Library.Domain.Entities.Usuario_y_categoria;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) 
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
