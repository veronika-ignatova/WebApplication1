using Core.Interface;

namespace Core.Entities
{
    public class Image : IImage
    {
        public string? Name { get; set; }
        public byte[]? Data { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}