namespace ImdbLite.Data.Models.Writer
{
    using ImdbLite.Data.Models.Base;

    public class WritersPhoto : Photo
    {
        public int WriterId { get; set; }

        public virtual Writer Writer { get; set; }
    }
}
