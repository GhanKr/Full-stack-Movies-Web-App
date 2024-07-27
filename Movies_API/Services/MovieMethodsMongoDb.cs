using DnsClient.Protocol;
using MongoDB.Bson;
using MongoDB.Driver;
using Movies_API.Model;
using Movies_API.MongoDbMovieSource;
using Movies_API.MongoDbMovieSource.Entities;

namespace Movies_API.Services
{
    public class MovieMethodsMongoDb: IMovieMethods
    {
        private MongoDbMovieContext _mongoDbContext;

        public MovieMethodsMongoDb(MongoDbMovieContext MovieContext) { 
         _mongoDbContext = MovieContext;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var mongoFilter = Builders<MovieMongoDb>.Filter.Empty;
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();

            List<Movie> moviesResult = new List<Movie>();
            foreach (var movie in document)
            {
                


                moviesResult.Add(new Movie()
                {
                    Title = movie.Title,
                    Cast = movie.Cast,
                    Genre = movie.Genre,
                    Budget = movie.Budget,
                    Description = movie.Description,
                    Popularity = movie.Popularity,
                    ReleaseDate = movie.ReleaseDate,
                    Revenue = movie.Revenue,
                    RunTime = movie.RunTime,
                    PosterUrl = movie.PosterUrl,
                    VoteAverage = movie.VoteAverage,
                    VoteCount = movie.VoteCount


                });
            }
            return moviesResult;
        }

        public IEnumerable<Movie> GetMoviesByGenre(string? Genre)
        {

           
            var mongoFilter = Builders<MovieMongoDb>.Filter.All("genres",new[] { Genre });
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();

            List<Movie> moviesResult = new List<Movie>(); 
            foreach (var movie in document)
            {
                


                moviesResult.Add(new Movie()
                {
                    Title = movie.Title,
                    Cast = movie.Cast,
                    Genre = movie.Genre,
                    Budget = movie.Budget,
                    Description = movie.Description,
                    Popularity = movie.Popularity,
                    ReleaseDate = movie.ReleaseDate,
                    Revenue = movie.Revenue,
                    RunTime = movie.RunTime,
                    PosterUrl = movie.PosterUrl,
                    VoteAverage = movie.VoteAverage,
                    VoteCount = movie.VoteCount


                });
            }
            return moviesResult;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string? Title)
        {
            var mongoFilter = Builders<MovieMongoDb>.Filter.Eq("title", Title);
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();
            
            List<Movie> moviesResult = new List<Movie>();
            foreach(var movie in document)
            {
                


                moviesResult.Add(new Movie()
                {
                    Title = movie.Title,
                     Cast = movie.Cast,
                     Genre = movie.Genre,
                     Budget = movie.Budget,
                      Description = movie.Description,
                       Popularity = movie.Popularity,
                        ReleaseDate = movie.ReleaseDate,
                         Revenue    = movie.Revenue,
                          RunTime   = movie.RunTime,
                           PosterUrl = movie.PosterUrl,
                            VoteAverage = movie.VoteAverage,
                            VoteCount = movie.VoteCount

                     
                });
            }
            return moviesResult;
        }

        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
