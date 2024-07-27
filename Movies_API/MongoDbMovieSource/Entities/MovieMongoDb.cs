using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Movies_API.MongoDbMovieSource.Entities
{
    public class MovieMongoDb
    {
        public ObjectId Id { get; set; }
        [BsonElement("id")]
        public int Idd { get; set; }
        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("vote_average")]
        public double  VoteAverage { get; set; }
        [BsonElement("vote_count")]
        public int VoteCount {  get; set; }
        [BsonElement("status")]
        public string? Status { get; set; }
        [BsonElement("release_date")]
        public string? ReleaseDate {  get; set; }

        [BsonElement("revenue")]
        public int Revenue { get; set; }

        [BsonElement("runtime")]
        public int RunTime { get; set; }

        [BsonElement("budget")]
        public int Budget { get; set; }
        [BsonElement("imdb_id")]
        public string? ImdbId {  get; set; }
        [BsonElement("original_language")]
        public string? OriginalLanguage { get; set; }
        [BsonElement("original_title")]
        public string? Original_Title {  get; set; }
        [BsonElement("overview")]
        public string? Description { get; set; }
        [BsonElement("popularity")]
        public double Popularity { get; set; }
        [BsonElement("tagline")]
        public string? Tagline { get; set; }
        [BsonElement("genres")]
        public List<string?> Genre { get; set; }
        [BsonElement("production_companies")]
        public string? ProductionCompanies { get; set; }
        [BsonElement("production_countries")]
        public string? ProductionCountries { get; set; }
        [BsonElement("spoken_languages")]
        public string? SpokenLanguages {  get; set; }
        [BsonElement("cast")]
        public List<string?> Cast {  get; set; }
        [BsonElement("director")]
        public string? Directors { get; set; }
        [BsonElement("director_of_photography")]
        public string? DirectorofPhotography {  get; set; }
        [BsonElement("writers")]
        public string? Writers {  get; set; }
        [BsonElement("producers")]
        public string? Producers {  get; set; }
        [BsonElement("music_composer")]
        public string? MusicComposer { get; set; }
        [BsonElement("adult")]
        public string? Adult { get; set; }
        [BsonElement("backdrop_path")]
        public string? Backdrop_path { get; set; }
        [BsonElement("homepage")]
        public string? Homepage { get; set; }
        [BsonElement("poster_path")]
        public string? PosterUrl { get; set; }
        [BsonElement("keywords")]
        public string? Keywords{ get; set; }                                             
                 
    }
}
