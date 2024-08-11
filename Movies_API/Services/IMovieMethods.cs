using Movies_API.Model;

namespace Movies_API.Services
{
    public interface IMovieMethods
    {
        //public IEnumerable<Movie> GetMovies(int pageNumber, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Movie> GetMovies(MovieFromQuery movieFromQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByYear(int year);

        public IEnumerable<Movie> GetMoviesByTitle(string? Title);

        public IEnumerable<Movie> GetMoviesByGenre(string? Genre);
                          
    }
}
