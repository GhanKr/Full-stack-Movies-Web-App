using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Movies_API.Model
{
    public class MovieFromQuery
    {
        /// <summary>
        /// query by title <br/>
        /// example: movie?title=MrBean
        /// </summary>
        public string title { get; set; } = "";

        /// <summary>
        /// query by Genre availabe, can query by multiple genres at once <br/>
        /// example: movie?genre=Horror,Comedy <br/>
        /// it will return all the movies with either Horror or Comedy genre <br/>
        /// Caution: First letter of every Genre should be capital
        /// </summary>
        public string? genre { get; set; }
        /// <summary>
        /// query the movies by year released <br/>
        /// Example: movie?year=2021  
        /// Caution: only one year can be queried at once
        /// </summary>
        public int year { get; set; }

        /// <summary>
        /// query all movies which are greater than or equal to the year <br/>
        /// example: movies?yearGte=2021
        /// </summary>
        public int yearGte { get; set; }

        /// <summary>
        /// query all movies which are equal to and less than the year <br/>
        /// Example : movies?yearLte=2021
        /// </summary>

        public int yearLte { get; set; }

        /// <summary>
        /// sort the movies returned in ascending order <br/>
        /// support multiple sorting by title,year,genre <br/>
        /// Caution:Order given is mattered, ex: sort by title,year is different than sort by year,title <br/>
        /// Example: movie?sortAsc=year,title <br/>
        /// it will first sort by year and then by title
        /// </summary>
        public string? sortAsc { get; set; }

        /// <summary>
        /// sort the movies returned in descending order, <br/>
        /// support multiple sorting by title,year,genre <br/>
        /// Caution:Order given is mattered, ex: sort by title,year is different than sort by year,title <br/>
        /// Example: movie?sortDesc=year,title <br/>
        /// it will first sort by year and then by title
        /// </summary>
        public string? sortDesc { get; set; }

        /// <summary>
        /// limit the number or movies returned <br/>
        /// Example: movies?=limit =50 <br/>
        /// it will only return 50 movies
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// offest the result <br/>
        /// Example: movies?offset=50 <br/>
        /// it will offset by 50 pages and start returning after result
        /// </summary>
        public int offset { get; set; } = 1;
       


    }
}
