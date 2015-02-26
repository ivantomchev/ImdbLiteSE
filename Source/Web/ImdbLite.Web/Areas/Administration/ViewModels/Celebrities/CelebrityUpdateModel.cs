namespace ImdbLite.Web.Areas.Administration.ViewModels.Celebrities
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;

    using ImdbLite.Data.Models;
    using ImdbLite.Web.Infrastructure.Mapping;

    public class CelebrityUpdateModel : IMapFrom<Celebrity>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        public string FullName { get; set; }

        [UIHint("UploadFile")]
        public HttpPostedFileBase FileToUpload { get; set; }

        public CelebrityMainPhoto Photo { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CelebrityUpdateModel, Celebrity>()
                .ForMember(d => d.Photo, opt => opt.MapFrom(s => s.FileToUpload != null ? Mapper.Map<CelebrityMainPhoto>(s.FileToUpload) : s.Photo));
        }
    }
}