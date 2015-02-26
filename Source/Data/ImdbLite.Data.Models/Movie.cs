namespace ImdbLite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ImdbLite.Data.Models.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie : BaseEntity
    {
        private ICollection<Character> characters;
        private ICollection<CastMember> castMembers;
        private ICollection<Genre> genres;

        public Movie()
        {
            this.characters = new HashSet<Character>();
            this.castMembers = new HashSet<CastMember>();
            this.genres = new HashSet<Genre>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string OfficialTrailer { get; set; }

        public virtual MoviePoster Poster { get; set; }

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

        public virtual ICollection<CastMember> CastMembers
        {
            get
            {
                return this.castMembers;
            }
            set
            {
                this.castMembers = value;
            }
        }
    }
}
