using Movies_API.Model;

namespace Movies_API.Services
{
    public interface IMovieMethods
    {
        public IEnumerable<Movie> GetMovies(int pageNumber, int pageSize);

        public IEnumerable<Movie> GetMoviesByYear(int year);

        public IEnumerable<Movie> GetMoviesByTitle(string? Title);

        public IEnumerable<Movie> GetMoviesByGenre(string? Genre);
                          
    }
}
