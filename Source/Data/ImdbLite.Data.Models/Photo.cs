namespace ImdbLite.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ImdbLite.Data.Common.Models;

    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }
    }
}
