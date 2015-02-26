namespace ImdbLite.Web.Areas.Administration.ViewModels.CastMembers
{
    using System.Web.Mvc;

    using ImdbLite.Web.Infrastructure.Mapping;
    using ImdbLite.Data.Models;

    public class CastMemberInputModel : IMapFrom<CastMember>
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public int CelebrityId { get; set; }

        [HiddenInput]
        public ParticipationType Participation { get; set; }

        [HiddenInput]
        public int MovieId { get; set; }
    }
}