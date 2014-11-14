namespace ImdbLite.Data.Models.Director
{
    using ImdbLite.Data.Models.Base;

    public class DirectorsComment : Comment
    {
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }
    }
}
