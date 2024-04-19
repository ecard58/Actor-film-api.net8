using Ator_Filme.Models;
using Microsoft.EntityFrameworkCore;

namespace Ator_Filme.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ActorModel> Actors { get; set; }
        public DbSet<FilmModel> Films { get; set; }
    
    }
}
