using Microsoft.AspNetCore.Mvc;
using Movies_API.Model;
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
       [HttpGet("genre/{Genre}")]
        public ActionResult<IEnumerable<Movie>> MoviesByGenre(string? Genre)
        {
            var movieList = _iMovieMethods.GetMoviesByGenre(Genre);

            return Ok(movieList);
        }
    }
}
