using Microsoft.EntityFrameworkCore;
namespace ParcialLibro.Models
{
    public class LibroContext : DbContext
    {
        public LibroContext (DbContextOptions<LibroContext> options):
        base(options)
        {
            
        }
        public DbSet<LibroItem> libroItems{get; set;} 
    }
}