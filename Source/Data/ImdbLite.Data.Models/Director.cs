namespace ImdbLite.Data.Models
{
    using System.Collections.Generic;
    using ImdbLite.Data.Models.Base;
    using ImdbLite.Data.Models;

    public class Director : CastMember
    {
        private ICollection<Movie> movies;

        public Director()
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
