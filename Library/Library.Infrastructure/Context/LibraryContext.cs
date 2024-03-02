
using Library.Domain.Entities.Production;
using Library.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        } 
        
        public DbSet<Libro> Libros { get; set; }

    }
}
