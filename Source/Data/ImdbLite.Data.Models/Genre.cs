namespace ImdbLite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ImdbLite.Data.Common.Models;
    using ImdbLite.Data.Models;


    public class Genre : IAuditInfo, IDeletableEntity
    {
        private ICollection<Movie> movies;

        [Key]
        public int Id { get; set; }

        [Required]
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
