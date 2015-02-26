namespace ImdbLite.Web.Areas.Administration.ViewModels.Movies
{
    using System.Collections.Generic;

    using ImdbLite.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models;

    public class MovieIndexViewModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public MoviePoster Poster { get; set; }
    }
}