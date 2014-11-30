namespace ImdbLite.Web.Areas.Administration.ViewModels.Genres
{
    using ForumSystem.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models.Genre;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GenreDetailsViewModel : GenreBaseViewModel, IMapFrom<Genre>
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}