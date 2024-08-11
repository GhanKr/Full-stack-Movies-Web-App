using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Movies_API.ConfigurationBindingClasses;
using Movies_API.MovieRepository.MongoDbMovieRepository.Entities;

namespace Movies_API.MovieRepository.MongoDbMovieRepository
{
    public class MongoDbMovieContext
    {


        public IMongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<MovieMongoDb> MongoMovieCollection { get; set; }

        public MongoDbMovieContext(IOptionsMonitor<DatabaseConfiguration> options)
        {

            DatabaseConfiguration MongoDbConfiguration = options.Get("MongoDb");
            Client = new MongoClient(MongoDbConfiguration.ConnectionString);
            Database = Client.GetDatabase(MongoDbConfiguration.Database);
            MongoMovieCollection = Database.GetCollection<MovieMongoDb>(MongoDbConfiguration.Collection);

        }


    }
}
