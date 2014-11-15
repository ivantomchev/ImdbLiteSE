namespace ImdbLite.Web.Areas.Administration.ViewModels.Base
{
    using AutoMapper;
    using ForumSystem.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    public abstract class CastMemberViewModel : IMapFrom<CastMember>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Biography { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<CastMember, CastMemberViewModel>()
                         .ForMember(m => m.FullName, options => options.MapFrom(c => c.FirstName + " " + c.LastName));
        }
    }
}