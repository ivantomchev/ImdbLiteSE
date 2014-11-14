namespace ImdbLite.Data.Models.Movie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ImdbLite.Data.Models.Actor;
    using ImdbLite.Data.Models.Director;
    using ImdbLite.Data.Models.Producer;
    using ImdbLite.Data.Models.Genre;
    using ImdbLite.Data.Models.Writer;

    public class Movie
    {
        private ICollection<Genre> genres;

        private ICollection<Producer> producedBy;

        private ICollection<Writer> writtenBy;

        private ICollection<Actor> actors;

        //private ICollection<Vote> votes;

        private ICollection<MoviesPhoto> photos;

        private ICollection<MoviesComment> comments;

        public Movie()
        {
            this.genres = new HashSet<Genre>();
            this.producedBy = new HashSet<Producer>();
            this.writtenBy = new HashSet<Writer>();
            this.actors = new HashSet<Actor>();
            //this.votes = new HashSet<Vote>();
            this.photos = new HashSet<MoviesPhoto>();
            this.comments = new HashSet<MoviesComment>();
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

        public string PosterUrl { get; set; }

        public ICollection<MoviesPhoto> Photos
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

        public virtual ICollection<Actor> Actors
        {
            get
            {
                return this.actors;
            }
            set
            {
                this.actors = value;
            }
        }

        //public virtual ICollection<Vote> Votes
        //{
        //    get
        //    {
        //        return this.votes;
        //    }
        //    set
        //    {
        //        this.votes = value;
        //    }
        //}

        public virtual ICollection<MoviesComment> Comments
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
    }
}
