using System.Diagnostics;
using System.IO;

namespace Movies_API.MovieStagingArea
{
    public class MovieStagingClass
    {
        public int id;
        public Object? title {  get; set; }
public float vote_average { get; set; }
public int vote_count { get; set; }
public string? status;
public string? release_date {  get; set; }
public int revenue { get; set; }
public int runtime { get; set; }
public int budget {  get; set; }
public string? imdb_id;
public string? original_language;
public string?  original_title;
public string? overview {  get; set; }
public float popularity { get; set; }
public string? tagline;
public string? genres { get; set; }
        public string? production_companies;
public string? production_countries;
public string? spoken_languages;
public string? cast { get; set; }   
public string? director { get; set; }
public string? director_of_photography { get; set; }
public string? writers { get; set; }
public string? producers { get; set; }
public string? music_composer { get; set; }
public string?  adult;
public string? backdrop_path;
public string?  homepage;
public string?  poster_path { get; set; }
public string?  keywords;

    }
}
