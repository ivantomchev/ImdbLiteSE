namespace ImdbLite.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    using ImdbLite.Data.Common.Models;

    public class CastMember : IAuditInfo, IDeletableEntity
    {
        private ICollection<Photo> photos;
        private ICollection<Movie> directedMovies;
        private ICollection<Movie> producedMovies;
        private ICollection<Movie> writtenMovies;
        private ICollection<Character> characters;

        public CastMember()
        {
            this.photos = new HashSet<Photo>();
            this.directedMovies = new HashSet<Movie>();
            this.producedMovies = new HashSet<Movie>();
            this.writtenMovies = new HashSet<Movie>();
            this.characters = new HashSet<Character>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthCity { get; set; }

        public string BirthCountry { get; set; }

        public string Biography { get; set; }

        public int MainPhotoId { get; set; }

        public virtual Photo MainPhoto { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Photo> Photos
        {
            get
            {
                return this.photos;
            }

            set
            {
                this.photos = value;
            }
        }

        public int DirectedMovieId { get; set; }

        public virtual ICollection<Movie> DirectedMovies
        {
            get
            {
                return this.directedMovies;
            }

            set
            {
                this.directedMovies = value;
            }
        }

        public int ProducedMovieId { get; set; }

        public virtual ICollection<Movie> ProducedMovies
        {
            get
            {
                return this.producedMovies;
            }

            set
            {
                this.producedMovies = value;
            }
        }

        public int WrittenMovieId { get; set; }

        public virtual ICollection<Movie> WrittenMovies
        {
            get
            {
                return this.writtenMovies;
            }

            set
            {
                this.writtenMovies = value;
            }
        }

        public virtual ICollection<Character> Characters
        {
            get
            {
                return this.characters;
            }

            set
            {
                this.characters = value;
            }
        }
    }
}
