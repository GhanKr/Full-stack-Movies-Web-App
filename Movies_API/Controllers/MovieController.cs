using Microsoft.AspNetCore.Mvc;
using Movies_API.Model;
using Movies_API.MongoDbMovieSource;
using Movies_API.Services;

namespace Movies_API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieMethods _iMovieMethods;
       
        public MovieController(IMovieMethods MovieMethod) { 
            _iMovieMethods = MovieMethod;
           
        }
       [HttpGet("title/{Title}")]
        public ActionResult<IEnumerable<Movie>> MoviesByGenre(string? Title)
        {
            var movieList = _iMovieMethods.GetMoviesByTitle(Title);

            return Ok(movieList);
        }
        [HttpGet]
        public  ActionResult<IEnumerable<Movie>> AllMovies() { 
            var movieList = _iMovieMethods.GetMovies();
            return Ok(movieList);
        }
        [HttpGet("genres/{Genres}")]
        public ActionResult<IEnumerable<Movie>> MoviesByGenres(string? Genres)
        {
            var movieList = _iMovieMethods.GetMoviesByGenre(Genres);
            return Ok(movieList);
        }
    }
}
