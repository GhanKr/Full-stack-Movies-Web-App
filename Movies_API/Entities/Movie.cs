namespace Movies_API.Entities
{
    public class Movie
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ReleaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set;}

        public int RunTime { get; set; }
        public int Revenue { get; set; }
        public int Budget { get; set; }
        public float Popularity { get; set; }

        public string? PosterUrl { get; set; }

        public Genre Genre { get; set; }
        public Cast Cast { get; set; }


    }
}
