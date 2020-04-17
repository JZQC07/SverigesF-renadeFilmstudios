using Microsoft.EntityFrameworkCore;
using SFF.Models;
namespace SFF.Models
{
    public class GlobalDbContext : DbContext
    {
        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options)
        {

        }
        public GlobalDbContext()
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<SFF.Models.MovieStudio> MovieStudio { get; set; }

        public DbSet<SFF.Models.Review> Review { get; set; }

        public DbSet<SFF.Models.Label> Label { get; set; }

        public DbSet<SFF.Models.RentedMovies> RentedMovies { get; set; }
    }
}