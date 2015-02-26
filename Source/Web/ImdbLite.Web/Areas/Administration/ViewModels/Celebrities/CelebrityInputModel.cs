namespace ImdbLite.Web.Areas.Administration.ViewModels.Celebrities
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;

    using ImdbLite.Data.Models;
    using ImdbLite.Web.Infrastructure.Mapping;

    public class CelebrityInputModel : IMapFrom<Celebrity>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        public string FullName { get; set; }

        [UIHint("UploadFile")]
        [Required(ErrorMessage = "Please Select Image")]
        public HttpPostedFileBase FileToUpload { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CelebrityInputModel, Celebrity>()
                .ForMember(d => d.Photo, opt => opt.MapFrom(s => s.FileToUpload));
        }
    }
}