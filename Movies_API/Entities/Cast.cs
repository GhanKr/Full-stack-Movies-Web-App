using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_API.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Movie Movie { get; set; }
        [ForeignKey(nameof(Movie))]

        public int MovieId { get; set; }

    }
}
