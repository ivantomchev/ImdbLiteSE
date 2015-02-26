namespace ImdbLite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ImdbLite.Data.Models.Base;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Celebrity : BaseEntity
    {
        private ICollection<Character> characters;
        private ICollection<CastMember> castMembers;

        public Celebrity()
        {
            this.characters = new HashSet<Character>();
            this.castMembers = new HashSet<CastMember>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public virtual CelebrityMainPhoto Photo { get; set; }

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
