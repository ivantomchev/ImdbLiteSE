﻿namespace ImdbLite.Web.Areas.Administration.ViewModels.Movies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using ImdbLite.Data.Models;
    using ImdbLite.Web.Areas.Administration.ViewModels.CastMembers;
    using ImdbLite.Web.Areas.Administration.ViewModels.Characters;
    using ImdbLite.Web.Infrastructure.Mapping;

    public class MovieInputModel : IMapFrom<Movie>, IHaveCustomMappings, IMovieInputModel
    {
        public MovieInputModel()
        {
            this.Characters = new List<CharacterInputModel>();
            this.CastMembers = new HashSet<CastMemberInputModel>();
            this.Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        [UIHint("SingleLineText")]
        [Required]
        public string Title { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Official Trailer")]
        [Required]
        public string OfficialTrailer { get; set; }

        [UIHint("UploadFile")]
        [Required]
        public HttpPostedFileBase FileToUpload { get; set; }

        public MoviePoster Poster { get; set; }

        public IList<CharacterInputModel> Characters { get; set; }

        public ICollection<CastMemberInputModel> CastMembers { get; set; }

        public IEnumerable<SelectListItem> Celebrities { get; set; }

        public IEnumerable<SelectListItem> GenresList { get; set; }

        public ICollection<Genre> Genres { get; set; }

        [Display(Name = "Producers")]
        public int[] selectedProducers { get; set; }

        [Display(Name = "Directors")]
        public int[] selectedDirectors { get; set; }

        [Display(Name = "Actors")]
        public int[] selectedCharacters { get; set; }

        [Display(Name = "Genres")]
        public int[] selectedGenres { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //Projest From ViewModel To DbModel
            configuration.CreateMap<MovieInputModel, Movie>()
                .ForMember(d => d.Poster, opt => opt.MapFrom(s => s.FileToUpload != null ? Mapper.Map<MoviePoster>(s.FileToUpload) : s.Poster));

            ////Project From DbModel To ViewModel
            configuration.CreateMap<Movie, MovieInputModel>()
                .ForMember(d => d.selectedGenres, opt => opt.MapFrom(s => s.Genres.Select(x => x.Id)))
                .ForMember(d => d.selectedDirectors, opt => opt.MapFrom(s => s.CastMembers.Where(x => x.Participation == ParticipationType.Director).Select(x => x.CelebrityId)))
                .ForMember(d => d.selectedProducers, opt => opt.MapFrom(s => s.CastMembers.Where(x => x.Participation == ParticipationType.Producer).Select(x => x.CelebrityId)))
                .ForMember(d => d.selectedCharacters, opt => opt.MapFrom(s => s.Characters.Select(x => x.CelebrityId)));
        }
    }
}