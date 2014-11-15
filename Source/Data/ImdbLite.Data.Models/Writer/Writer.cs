namespace ImdbLite.Data.Models.Writer
{
    using System.Collections.Generic;
    using ImdbLite.Data.Models.Base;

    public class Writer : CastMember
    {
        private ICollection<WritersComment> comments;
        private ICollection<WritersPhoto> photos;

        public Writer()
            : base()
        {
            this.comments = new HashSet<WritersComment>();
            this.photos = new HashSet<WritersPhoto>();
        }

        public virtual ICollection<WritersComment> Comments
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

        public virtual ICollection<WritersPhoto> Photos
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
