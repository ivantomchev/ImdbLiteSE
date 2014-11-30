namespace ImdbLite.Web.Areas.Administration.ViewModels.Genres
{
    using ForumSystem.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models.Genre;
    using System.ComponentModel.DataAnnotations;

    public class GenreBaseViewModel: IMapFrom<Genre>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}