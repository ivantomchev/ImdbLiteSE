namespace ImdbLite.Web.Areas.Administration.ViewModels.Genres
{
    using System.ComponentModel.DataAnnotations;

    using ImdbLite.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models;

    public class GenreInputModel : IMapFrom<Genre>
    {
        [Required]
        [UIHint("SingleLineText")]
        public string Name { get; set; }
    }
}