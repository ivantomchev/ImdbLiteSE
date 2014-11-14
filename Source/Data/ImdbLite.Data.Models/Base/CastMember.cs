namespace ImdbLite.Data.Models.Base
{
    using ImdbLite.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ImdbLite.Data.Models.Movie;

    public abstract class CastMember : IAuditInfo, IDeletableEntity
    {
        private ICollection<Movie> movies;

        public CastMember()
        {
            this.movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthCity { get; set; }

        public string BirthCountry { get; set; }

        public string MainPhotoUrl { get; set; }

        public string Biography { get; set; }

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

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
