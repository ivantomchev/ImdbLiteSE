namespace ImdbLite.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    using ImdbLite.Data.Common.Models;

    public abstract class CastMember : IAuditInfo, IDeletableEntity
    {
        private ICollection<Photo> photos;

        public CastMember()
        {
            this.photos = new HashSet<Photo>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthCity { get; set; }

        public string BirthCountry { get; set; }

        public string Biography { get; set; }

        public int MainPhotoId { get; set; }

        public virtual Photo MainPhoto { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

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
    }
}
