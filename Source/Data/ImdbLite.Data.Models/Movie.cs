namespace ImdbLite.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ImdbLite.Data.Models;

    public class Movie
    {
        private ICollection<Genre> genres;

        private ICollection<Producer> producedBy;

        private ICollection<Writer> writtenBy;

        private ICollection<Photo> photos;

        private ICollection<Comment> comments;

        private ICollection<Character> characters;

        public Movie()
        {
            this.genres = new HashSet<Genre>();
            this.producedBy = new HashSet<Producer>();
            this.writtenBy = new HashSet<Writer>();
            this.photos = new HashSet<Photo>();
            this.comments = new HashSet<Comment>();
            this.characters = new HashSet<Character>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Measured in minutes
        /// </summary>
        public int Duration { get; set; }

        public string StoryLine { get; set; }

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

        public string TrailerUrl { get; set; }

        public virtual ICollection<Genre> Genres
        {
            get
            {
                return this.genres;
            }

            set
            {
                this.genres = value;
            }
        }

        public virtual Director DirectedBy { get; set; }

        public virtual ICollection<Producer> ProducedBy
        {
            get
            {
                return this.producedBy;
            }

            set
            {
                this.producedBy = value;
            }
        }

        public virtual ICollection<Writer> WrittenBy
        {
            get
            {
                return this.writtenBy;
            }

            set
            {
                this.writtenBy = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
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
