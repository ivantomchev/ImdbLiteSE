namespace ImdbLite.Data.Models.Actor
{
    using System.Collections.Generic;
    using ImdbLite.Data.Models.Base;
    
    public class Actor : CastMember
    {
        private ICollection<ActorsComment> comments;
        private ICollection<ActorsPhoto> photos;

        public Actor()
            : base()
        {
            this.comments = new HashSet<ActorsComment>();
            this.photos = new HashSet<ActorsPhoto>();
        }

        public virtual ICollection<ActorsComment> Comments
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

        public virtual ICollection<ActorsPhoto> Photos
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
    }
}
