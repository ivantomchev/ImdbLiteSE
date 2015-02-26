namespace ImdbLite.Data.Models.Base
{
    public abstract class Image
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }

        public string Type { get; set; }
    }
}
