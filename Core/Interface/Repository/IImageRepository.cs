
namespace Core.Interface.Repository
{
    public interface IImageRepository
    {
        IImage? GetImageByName(string name);
        public bool CreateImage(IImage image);
        bool UpdateImage(IImage image);
    }
}
