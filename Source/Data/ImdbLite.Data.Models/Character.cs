namespace ImdbLite.Data.Models
{    
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ImdbLite.Data.Common.Models;
    using ImdbLite.Data.Models;

    public class Character : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int PlayedById { get; set; }

        public virtual Actor PlayedBy { get; set; }

        public int FromMovieId { get; set; }

        public virtual Movie FromMovie { get; set; }
    }
}
