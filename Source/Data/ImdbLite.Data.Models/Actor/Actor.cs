
using ImdbLite.Data.Models.Base;
using System.Collections.Generic;
namespace ImdbLite.Data.Models.Actor
{
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
