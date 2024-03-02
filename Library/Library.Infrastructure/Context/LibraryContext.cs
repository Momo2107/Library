

using Library.Domain.Entities.Esta.Prestam_y_Num.Correlativo;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) 
        {
        }
        public DbSet<NumeroCorrelativo> NumeroCorrelativo { get; set; }
        public DbSet<EstadoPrestamo> EstadoPrestamo { get; set; }
    }
}
