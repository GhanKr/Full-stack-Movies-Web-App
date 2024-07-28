using DnsClient.Protocol;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

       

        public IEnumerable<Movie> GetMovies(int pageNumber=1,int pageSize=10) {
            var mongoFilter = Builders<MovieMongoDb>.Filter.Empty;
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).Sort("release_date")
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .ToList();
            List<Movie> moviesResult = populateMovieList(document);

            
            return moviesResult;
        }
        public IEnumerable<Movie> GetMoviesByGenre(string? Genre)
        {

           
            var mongoFilter = Builders<MovieMongoDb>.Filter.All("genres",new[] { Genre });
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();
            List<Movie> moviesResult = populateMovieList(document);
          
            return moviesResult;
        }

        private List<Movie> populateMovieList(List<MovieMongoDb> document)
        {
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
                    ReleaseDate = movie.ReleaseDate.ToString("dd/MM/yy"),
                    Revenue = movie.Revenue,
                    RunTime = movie.RunTime,
                    PosterUrl = movie.PosterUrl,
                    VoteAverage = movie.VoteAverage,
                    VoteCount = movie.VoteCount,
                    Directors = movie.Directors,


                });
            }
            return moviesResult ;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string? Title)
        {
            var mongoFilter = Builders<MovieMongoDb>.Filter.Eq("title", Title);
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();
            
          
            List<Movie> moviesResult = populateMovieList(document);

            
            return moviesResult;
        }

        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            DateTime fromDate = new DateTime(year, 01, 01);
            DateTime toDate = new DateTime(year, 12, 31);
            var mongoFilter = Builders<MovieMongoDb>.Filter.Gte("release_date", fromDate) &
                              Builders<MovieMongoDb>.Filter.Lte("release_date", toDate);

            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();
            List<Movie> moviesResult = populateMovieList(document);

            return moviesResult;
        }
           
        
    }
}
