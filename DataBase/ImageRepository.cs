using Core.Interface;
using Core.Interface.Repository;
using DataBase.Models;

namespace DataBase
{
    public class ImageRepository : IImageRepository
    {
        protected readonly MyDbContext _myDbContext;
        public ImageRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public IImage? GetImageByName(string name)
        {
            return _myDbContext.Images.FirstOrDefault(x => x.Name == name);
        }

        public bool CreateImage(IImage image)
        {
            try
            {
                _myDbContext.Images.Add(new Image()
                {
                    Data = image.Data,
                    Name = image.Name,
                    UpdateDate = DateTime.Now
                });
                _myDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateImage(IImage image)
        {
            try
            {
                var dbImage = _myDbContext.Images.FirstOrDefault(x => x.Name == image.Name);
                if (dbImage != null)
                {
                    dbImage.UpdateDate = DateTime.Now;
                    dbImage.Name = image.Name;
                    _myDbContext.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
