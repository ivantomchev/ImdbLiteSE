namespace ImdbLite.Data.Models.Producer
{
    using ImdbLite.Data.Models.Base;

    public class ProducersComment : Comment
    {
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }
    }
}
