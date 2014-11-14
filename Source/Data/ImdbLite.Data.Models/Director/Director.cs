using ImdbLite.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbLite.Data.Models.Director
{
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
