using DnsClient.Protocol;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Azure;
using MongoDB.Bson;
using MongoDB.Driver;
using Movies_API.Model;
using Movies_API.MovieRepository.MongoDbMovieRepository;
using Movies_API.MovieRepository.MongoDbMovieRepository.Entities;

namespace Movies_API.Services
{
    public class MovieMethodsMongoDb: IMovieMethods
    {
        private MongoDbMovieContext _mongoDbContext;

        public MovieMethodsMongoDb(MongoDbMovieContext MovieContext) { 
         _mongoDbContext = MovieContext;
        }

       

        public IEnumerable<Movie> GetMovies(MovieFromQuery movieFromQuery) {
            var mongoFilter = Builders<MovieMongoDb>.Filter;
          

            var sortCondition = SortMovies(movieFromQuery);

            var filter = FilterByRangeOfYear(movieFromQuery);


            
            var document = _mongoDbContext.MongoMovieCollection.Find(filter).
                Sort(sortCondition).
                Skip((movieFromQuery.offset-1)*movieFromQuery.limit).
                Limit(movieFromQuery.limit).ToList();


            List<Movie> moviesResult = populateMovieList(document);


            return moviesResult.Where(movie => DateTime.Parse(movie.ReleaseDate) <= DateTime.Now);
            
        }

        private SortDefinition<MovieMongoDb> SortMovies(MovieFromQuery movieFromQuery)
        {
            var sortBuilder = Builders<MovieMongoDb>.Sort;


            SortDefinition<MovieMongoDb> sortResult;

            List<SortDefinition<MovieMongoDb>> sortConditionList= new();

            if (movieFromQuery.sortAsc == null && movieFromQuery.sortDesc == null)
            {
               return  sortBuilder.Ascending(movie => movie.Title);
            }

            if(movieFromQuery.sortDesc != null)
            {
                foreach(string sortconditon in movieFromQuery.sortDesc.Split(",")){

                    if (sortconditon == "year")
                    {
                        sortConditionList.Add(sortBuilder.Descending(movie => movie.ReleaseDate));
                    }

                    if (sortconditon == "genre")
                    {
                        sortConditionList.Add(sortBuilder.Descending(movie => movie.Genre));
                    }
                    if (sortconditon == "title")
                    {
                        sortConditionList.Add(sortBuilder.Descending(movie => movie.Title));
                    }

                    
                }

               

            }


            if (movieFromQuery.sortAsc != null)
            {
                foreach (string sortconditon in movieFromQuery.sortAsc.Split(","))
                {

                    if (sortconditon == "year")
                    {
                        sortConditionList.Add(sortBuilder.Ascending(movie => movie.ReleaseDate));
                    }

                    if (sortconditon == "genre")
                    {
                        sortConditionList.Add(sortBuilder.Ascending(movie => movie.Genre));
                    }
                    if (sortconditon == "title")
                    {
                        sortConditionList.Add(sortBuilder.Ascending(movie => movie.Title));
                    }


                }



            }

            sortResult = sortBuilder.Combine(sortConditionList);
            return sortResult;
        }

       
       

        private FilterDefinition<MovieMongoDb> FilterByTitle(MovieFromQuery movieFromQuery)
        {

            return Builders<MovieMongoDb>.Filter.Regex("title", movieFromQuery.title); ;
        }

        private FilterDefinition<MovieMongoDb> FilterByGenre(MovieFromQuery movieFromQuery)
        {
            var titleFilter = FilterByTitle(movieFromQuery);

            if (movieFromQuery.genre == null)
            {
                return titleFilter;
            }

            var genreFilter = Builders<MovieMongoDb>.Filter.AnyIn("genres", movieFromQuery.genre.Split(","));

            return genreFilter & titleFilter;
        }


        private FilterDefinition<MovieMongoDb> FilterByYear(MovieFromQuery movieFromQuery)
        {
            var genreFilter = FilterByGenre(movieFromQuery);
            
            if(movieFromQuery.year <=1980 || movieFromQuery.year >=2999) {
                return genreFilter;
            }

            DateTime fromDate = new DateTime(movieFromQuery.year, 01, 01);
            DateTime toDate = new DateTime(movieFromQuery.year, 12, 31);
            var fromDateFilter = Builders<MovieMongoDb>.Filter.Gte("release_date", fromDate);
            var toDateFilter = Builders<MovieMongoDb>.Filter.Lte("release_date", toDate);

            return fromDateFilter & toDateFilter & genreFilter;

        }

        private FilterDefinition<MovieMongoDb> FilterByRangeOfYear(MovieFromQuery movieFromQuery)
        {
            var yearFilter = FilterByYear(movieFromQuery);

            DateTime fromDate = new DateTime(1900, 01, 01);
            DateTime toDate = new DateTime(9999, 12, 31);

            if (movieFromQuery.yearGte <= 0 && movieFromQuery.yearLte <= 0)
            {
                return yearFilter;
            }

            if (movieFromQuery.yearGte >0)
            {
                fromDate = new DateTime(movieFromQuery.yearGte, 01, 01);
            }
            if (movieFromQuery.yearLte > 0)
            {
                toDate = new DateTime(movieFromQuery.yearLte, 12, 31);
            }
            var fromDateFilter = Builders<MovieMongoDb>.Filter.Gte("release_date", fromDate);
            var toDateFilter = Builders<MovieMongoDb>.Filter.Lte("release_date", toDate);

            return fromDateFilter & toDateFilter & yearFilter;


        }




        public IEnumerable<Movie> GetMoviesByGenre(string? Genre)
        {
           
            var mongoFilter = Builders<MovieMongoDb>.Filter.AnyIn("genres", Genre.Split(","));
            var document = _mongoDbContext.MongoMovieCollection.Find(mongoFilter).ToList();
            List<Movie> moviesResult = populateMovieList(document);
          
            return moviesResult;
        }

       
        public IEnumerable<Movie> GetMoviesByTitle(string? Title)
        {
            var mongoFilter = Builders<MovieMongoDb>.Filter.Regex("title", Title);
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
                    ReleaseDate = movie.ReleaseDate.ToString("MM/dd/yy"),
                    Revenue = movie.Revenue,
                    RunTime = movie.RunTime,
                    PosterUrl = movie.PosterUrl,
                    VoteAverage = movie.VoteAverage,
                    VoteCount = movie.VoteCount,
                    Directors = movie.Directors,


                });
            }
            return moviesResult;
        }



    }
}
