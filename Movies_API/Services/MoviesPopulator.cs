using Movies_API.Entities;
using Movies_API.MovieStagingArea;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Movies_API.Services
{
    public class MoviesPopulator
    {
        public static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler
    = ReferenceHandler.IgnoreCycles
        };
        public static List<MovieStagingClass> PopulateMovies()
        {
            List<Movie> movies = new List<Movie>();

            //List<MovieStagingClass> stagedMovie = new List<MovieStagingClass>();
            //MovieStagingClass stagedMovie = new MovieStagingClass();

            List<MovieStagingClass> stagedMovies= new List<MovieStagingClass>();




            string path = "C:\\Users\\Ghanshyam\\Desktop\\English_Movies_ Api\\Movies_API\\MoviesJsonSource\\2023-2024.json";

            using StreamReader streamReader = new(path);
            var json = streamReader.ReadToEnd();
            //json = json.First();

           
                stagedMovies = JsonSerializer.Deserialize<List<MovieStagingClass>>(json, _options);
                //return stagedMovies;
                //stagedMovies = stagedMovies.First();
           
           

            return stagedMovies;
        }
    }
}
