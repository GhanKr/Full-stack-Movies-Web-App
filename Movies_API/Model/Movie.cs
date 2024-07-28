using Movies_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Movies_API.Model
{
    public class Movie
    {

        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        public int RunTime { get; set; }
        public int Revenue { get; set; }
        public int Budget { get; set; }
        public double Popularity { get; set; }

        public string? PosterUrl { get; set; }

        public List<string?> Genre { get; set; }
        public List<string?> Cast { get; set; }

        public List<string?> Directors { get; set; }
    }
}
