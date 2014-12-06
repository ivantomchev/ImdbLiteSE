namespace ImdbLite.Data.Models
{
    using System.Collections.Generic;
    using ImdbLite.Data.Models.Base;
    using ImdbLite.Data.Models;

    public class Writer : CastMember
    {
        private ICollection<Movie> movies;


        public Writer()
            : base()
        {
            this.movies = new HashSet<Movie>();
        }

        public virtual ICollection<Movie> Movies
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
