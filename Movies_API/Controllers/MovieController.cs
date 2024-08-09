using Microsoft.AspNetCore.Mvc;
using Movies_API.Model;
using Movies_API.MongoDbMovieSource;
using Movies_API.Services;

namespace Movies_API.Controllers
{
    [ApiController]
    [Route("/api/movie")]
    public class MovieController : ControllerBase
    {
        private IMovieMethods _iMovieMethods;

        public MovieController(IMovieMethods MovieMethod) {
            _iMovieMethods = MovieMethod;

        }
        [HttpGet("title/{Title}")]
        public ActionResult<IEnumerable<Movie>> MoviesByTitle(string? Title)
        {
            var movieList = _iMovieMethods.GetMoviesByTitle(Title);
            if (movieList.Count() == 0)
            {
                return NotFound("Movie doesn't exist");
            }

            return Ok(movieList);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> AllMovies(int pageNumber = 1, int pageSize = 10) {
            var movieList = _iMovieMethods.GetMovies(pageNumber, pageSize);
            return Ok(movieList);
        }
        [HttpGet("genres/{Genres}")]
        public ActionResult<IEnumerable<Movie>> MoviesByGenres(string? Genres)
        {
            var movieList = _iMovieMethods.GetMoviesByGenre(Genres);
            if (movieList.Count() == 0)
            {
                return NotFound("OOPS! No movies for this Genre");
            }
            return Ok(movieList);
        }

        [HttpGet("year/{year}")]
        public ActionResult<IEnumerable<Movie>> MoviesByYear(int year)
        {
            if (year<=1990 || year >= 2040)
            {
                return NotFound("Please enter valid year");
            }

            var movieList = _iMovieMethods.GetMoviesByYear(year);
            if (movieList.Count() == 0)
            {
                return NotFound("OOPS! No movies for this year");
            }
            return Ok(movieList);
        }

        [HttpPost("search")]
        public ActionResult<IEnumerable<Movie>> MoviesBySearch([FromBody] string? str)
        {

            var movieList = _iMovieMethods.GetMoviesByGenre(str);
            if (movieList.Count() == 0)
            {
                return NotFound("OOPS! No movies for this Genre");
            }
            return Ok(movieList);
        }
    }
}
