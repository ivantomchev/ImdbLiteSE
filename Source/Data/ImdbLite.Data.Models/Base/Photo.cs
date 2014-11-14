namespace ImdbLite.Data.Models.Base
{
    using ImdbLite.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Photo : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string AltText { get; set; }

        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
