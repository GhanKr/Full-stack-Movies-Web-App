using Movies_API.MovieRepository.SqlServerRepository.Entities;
using Movies_API.MovieStagingArea;
using System.Reflection;
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
        public static (List<Movie>,List<Genre>,List<Cast>) PopulateMovies(string source_path)
        {
            List<Movie> movies = new List<Movie>();
            List<Cast> casts = new List<Cast>();
            List <Genre> genres = new List<Genre>();    


            //List<MovieStagingClass> stagedMovie = new List<MovieStagingClass>();
            //MovieStagingClass stagedMovie = new MovieStagingClass();

            List<MovieStagingClass> stagedMovies= new List<MovieStagingClass>();


            

            string path = source_path;

            using StreamReader streamReader = new(path);
            var json = streamReader.ReadToEnd();
            int id = 1;
            int genreid = 1;
            int castid = 1;


           
            stagedMovies = JsonSerializer.Deserialize<List<MovieStagingClass>>(json, _options);

            foreach (MovieStagingClass stagemovie in stagedMovies)
            {
                movies.Add(new Movie()
                {
                    Id = id,
                    Title = stagemovie.title.ToString(),
                    Budget = stagemovie.budget,
                     
                    Description = stagemovie.overview,
                 
                    Popularity = stagemovie.popularity,
                    PosterUrl = stagemovie.poster_path,
                    ReleaseDate = stagemovie.release_date,
                    Revenue= stagemovie.revenue,
                    RunTime = stagemovie.runtime,
                    VoteAverage = stagemovie.vote_average,
                    VoteCount = stagemovie.vote_count

                });

                string[] tempGenre = stagemovie.genres.Split(",");
                foreach ( string gener in tempGenre)
                {
                    genres.Add(new Genre()
                    {
                        Id = genreid,
                        GenreName = gener,
                        MovieID = id
                    });
                    genreid++;
                }

                string[] tempcast = stagemovie.cast.Split(",");
                foreach (string cast in tempcast)
                {
                    casts.Add(new Cast()
                    {
                        Id = castid,
                         Name = cast,
                         MovieId = id
                    });
                    castid++;
                }
                id++;
            }
              
           
           

            return (movies,genres,casts);
        }
    }
}
