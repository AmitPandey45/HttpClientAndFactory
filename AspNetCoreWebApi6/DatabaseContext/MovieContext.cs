using AspNetCoreWebApi6.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.DatabaseContext
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null;
    }
}
