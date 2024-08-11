using Microsoft.EntityFrameworkCore;
using Movies_API.Model;
using Movies_API.MovieRepository.SqlServerRepository;

namespace Movies_API.Services
{
    public class MovieMethodsSqlServer : IMovieMethods
    {
        private MovieDbContext _dbContext;
        public MovieMethodsSqlServer(MovieDbContext DbContext) {
                _dbContext = DbContext;
        }
        //public  IEnumerable<Movie> GetMovies(int pageNumber, int pageSize)
        //{
        //    var movies =  _dbContext.Movies.Include(movie => movie.Genre).ToList();

        //    var genre = movies.Select(movie => movie.Genre.GenreName).ToList();

           
          
        //    List<Movie> result = new List<Movie>();
        //    foreach (var movie in movies)
        //    {
        //        result.Add(new Movie
        //        {
        //            Id = movie.Id,
        //            Title = movie.Title,
        //            Budget = movie.Budget,
        //            Description = movie.Description,
        //            Genre = genre,
        //            Popularity = movie.Popularity,
        //            ReleaseDate = movie.ReleaseDate,
        //            Revenue = movie.Revenue,
        //            RunTime = movie.RunTime,
        //            VoteAverage = movie.VoteAverage,
        //            VoteCount = movie.VoteCount,
        //            PosterUrl = movie.PosterUrl
        //        });
        //    }

        //    return result;

        //}

        public IEnumerable<Movie> GetMoviesByGenre(string? Genre)
        {
            var moviesByGenre = _dbContext.Movies
                                            .Include(movie => movie.Genre)
                                            .Where(movie => movie.Genre.GenreName == Genre)
                                            .ToList();

            List<string?> genre = new List<string?>();
            genre.Add(Genre);

            List<Movie> result = new List<Movie>();

            foreach (var movie in moviesByGenre)
            {
                result.Add(new Movie
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Budget = movie.Budget,
                    Description = movie.Description,
                    Genre = genre,
                    Popularity = movie.Popularity,
                    ReleaseDate = movie.ReleaseDate,
                    Revenue = movie.Revenue,
                    RunTime = movie.RunTime,
                    VoteAverage = movie.VoteAverage,
                    VoteCount = movie.VoteCount,
                    PosterUrl = movie.PosterUrl
                });
            }

            return result;

        }

        public IEnumerable<Movie> GetMoviesByTitle(string? Title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
