namespace ImdbLite.Web.Areas.Administration.ViewModels.Celebrities
{
    using ImdbLite.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models;

    public class CelebrityIndexViewModel : IMapFrom<Celebrity>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public CelebrityMainPhoto Photo { get; set; }
    }
}