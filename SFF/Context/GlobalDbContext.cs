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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=myDatabase.db");
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieStudio> MovieStudio { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<Label> Label { get; set; }

        public DbSet<RentedMovies> RentedMovies { get; set; }
    }
}