namespace ImdbLite.Web.Areas.Administration.ViewModels.Genres
{
    using ImdbLite.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models;

    public class GenreIndexViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}