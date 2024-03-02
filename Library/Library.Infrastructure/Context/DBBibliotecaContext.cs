

using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
    public class DBBibliotecaContext : DbContext
    {
        public DBBibliotecaContext(DbContextOptions<DBBibliotecaContext> options) : base(options) 
        {
        }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
