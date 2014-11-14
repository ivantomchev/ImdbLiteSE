namespace ImdbLite.Data.Models.Movie
{
    using ImdbLite.Data.Models.Base;

    public class MoviesPhoto : Photo
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
