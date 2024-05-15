using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;
namespace WebApiAutores
{
    public class ApplicationdbContext: DbContext
    {
        public ApplicationdbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }    
        
    }
}
