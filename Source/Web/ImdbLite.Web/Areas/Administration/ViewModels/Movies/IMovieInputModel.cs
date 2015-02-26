namespace ImdbLite.Web.Areas.Administration.ViewModels.Movies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    using ImdbLite.Data.Models;
    using ImdbLite.Web.Areas.Administration.ViewModels.CastMembers;
    using ImdbLite.Web.Areas.Administration.ViewModels.Characters;

    public interface IMovieInputModel
    {
        int Id { get; set; }

        [UIHint("SingleLineText")]
        string Title { get; set; }

        [UIHint("SingleLineText")]
        string OfficialTrailer { get; set; }

        [UIHint("UploadFile")]
        HttpPostedFileBase FileToUpload { get; set; }

        MoviePoster Poster { get; set; }

        IList<CharacterInputModel> Characters { get; set; }

        ICollection<CastMemberInputModel> CastMembers { get; set; }

        IEnumerable<SelectListItem> Celebrities { get; set; }

        IEnumerable<SelectListItem> GenresList { get; set; }

        ICollection<Genre> Genres { get; set; }

        int[] selectedProducers { get; set; }

        int[] selectedDirectors { get; set; }

        int[] selectedCharacters { get; set; }

        int[] selectedGenres { get; set; }
    }
}