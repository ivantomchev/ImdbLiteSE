namespace ImdbLite.Data.Models.Producer
{
    using System.Collections.Generic;
    using ImdbLite.Data.Models.Base;

    public class Producer : CastMember
    {
        private ICollection<ProducersComment> comments;
        private ICollection<ProducersPhoto> photos;

        public Producer()
            : base()
        {
            this.comments = new HashSet<ProducersComment>();
            this.photos = new HashSet<ProducersPhoto>();
        }

        public virtual ICollection<ProducersComment> Comments
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

        public virtual ICollection<ProducersPhoto> Photos
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
