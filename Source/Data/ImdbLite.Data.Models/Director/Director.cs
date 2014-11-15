namespace ImdbLite.Data.Models.Director
{
    using System.Collections.Generic;
    using ImdbLite.Data.Models.Base;

    public class Director : CastMember
    {
        private ICollection<DirectorsComment> comments;
        private ICollection<DirectorsPhoto> photos;

        public Director()
            : base()
        {
            this.comments = new HashSet<DirectorsComment>();
        }

        public virtual ICollection<DirectorsComment> Comments
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

        public virtual ICollection<DirectorsPhoto> Photos
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
