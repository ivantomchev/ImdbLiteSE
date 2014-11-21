namespace ImdbLite.Data.Models.Genre
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ImdbLite.Data.Models.Movie;
    using ImdbLite.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;

    public class Genre : IAuditInfo, IDeletableEntity
    {
        private ICollection<Movie> movies;

        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

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
