namespace ImdbLite.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using ImdbLite.Data.Common.Models;
    using ImdbLite.Data.Models.User;

    public abstract class Comment : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
