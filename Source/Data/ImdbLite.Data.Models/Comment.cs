namespace ImdbLite.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using ImdbLite.Data.Common.Models;
    using ImdbLite.Data.Models;

    public class Comment : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
