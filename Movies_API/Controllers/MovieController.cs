using Microsoft.AspNetCore.Mvc;
using Movies_API.Model;
 
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
        /// <summary>
        /// Get movies by title of the movies, it will return all movies containing that title part
        /// </summary>
        /// <param name="Title">The title of the movie</param>
        /// <returns>return ActionResult of the movie</returns>
        [HttpGet("title/{Title}")]
        public ActionResult<IEnumerable<Movie>> MoviesByTitle(string? Title)
        {
            var movieList = _iMovieMethods.GetMoviesByTitle(Title);
            if (movieList.Count() == 0)
            {
                return NotFound("Oops! Movie doesn't exist");
            }

            return Ok(movieList);
        }
        /// <summary>
        ///  Get All movies or You can query or sort by title,genre,year and limit and offset the result returned.
        /// </summary>
        /// <param name="movieFromQuery"> </param>
        /// <returns>Returns the movies</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get([FromQuery]  MovieFromQuery movieFromQuery) {
            var movieList = _iMovieMethods.GetMovies(movieFromQuery);
            if (movieList.Count() == 0)
            {
                return NotFound("OOPS! No movies found");
            }
            return Ok(movieList);
        }
        /// <summary>
        /// Get movies by all types of Genres, please input first letter as capital
        /// </summary>
        /// <param name="Genres">The genre for the movies</param>
        /// <returns></returns>
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
        /// <summary>
        /// Get all movies for a particular year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns></returns>
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

       
    }
}
