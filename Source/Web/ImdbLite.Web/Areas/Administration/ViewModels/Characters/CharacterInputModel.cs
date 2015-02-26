namespace ImdbLite.Web.Areas.Administration.ViewModels.Characters
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using ImdbLite.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models;

    public class CharacterInputModel : IMapFrom<Character>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [UIHint("SingleLineText")]
        [Required(ErrorMessage = "Please enter the character name!")]
        [StringLength(6)]
        public string CharacterName { get; set; }

        public int CelebrityId { get; set; }

        public string CelebrityName { get; set; }

        public int MovieId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Character, CharacterInputModel>()
                .ForMember(d => d.CelebrityName, opt => opt.MapFrom(s => s.Celebrity.FullName));
        }
    }
}