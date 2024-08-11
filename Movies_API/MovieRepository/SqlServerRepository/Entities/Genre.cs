using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_API.MovieRepository.SqlServerRepository.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }

        // public Movie Movie { get; set; }
        [ForeignKey(nameof(Movie))]
        public int MovieID { get; set; }

    }
}
