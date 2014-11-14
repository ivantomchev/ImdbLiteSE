namespace ImdbLite.Data.Models.Actor
{
    using ImdbLite.Data.Models.Base;

    public class ActorsPhoto : Photo
    {
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
