using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Movies_API.Entities;
using Movies_API.Services;

namespace Movies_API.MovieDbContexts
{
    public class MovieDbContext:DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cast> Casts { get; set; }

        public MovieDbContext (DbContextOptions<MovieDbContext> options) : base(options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    (List<Movie> movies, List<Genre> genres, List<Cast> casts) = MoviesPopulator.PopulateMovies(path);
        //    //modelBuilder.Entity<Movie>().HasData(movies);
        //    modelBuilder.Entity<Genre>().HasData(genres);
        //    //modelBuilder.Entity<Cast>().HasData(casts);
        //}
    }
}
