namespace ImdbLite.Data.Models.Genre
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ImdbLite.Data.Models.Movie;

    public class Genre
    {
        private ICollection<Movie> movies;

        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<Movie> Movies
        {
            get
            {
                return this.movies;
            }

            set
            {
                this.movies = value;
            }
        }
    }
}
