using MongoDB.Driver;
using Movies_API.MongoDbMovieSource.Entities;

namespace Movies_API.MongoDbMovieSource
{
    public class MongoDbMovieContext
    {

       
        public IMongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<MovieMongoDb> MongoMovieCollection { get; set; }

        public MongoDbMovieContext()
        {
            
            Client = new MongoClient( );
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            Database = Client.GetDatabase(configuration.GetSection("MongoDbSourceConfiguration")["database"]);
            MongoMovieCollection = Database.GetCollection<MovieMongoDb>(configuration.GetSection("MongoDbSourceConfiguration")["collection"]);

        }
      
        
    }
}
