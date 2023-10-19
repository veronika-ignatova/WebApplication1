using Core.Entities;
using Core.Interface;
using Core.Interface.Repository;
using Core.Interface.Service;

namespace Core.Service
{
    public class ImageService : IImageService
    {
        protected readonly IImageRepository imageRepository;
        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<byte[]> GetImage(int? id, string? name)
        {
            if (!string.IsNullOrEmpty(name) && id.HasValue && id.Value != 0)
            {
                var imageName = GetImageName(id, name);
                if (ImageCache.IsImageDownload(imageName))
                {
                    return ImageCache.GetImages(imageName);
                }
                else
                {
                    if (IsImageInBase(imageName, out IImage dbImage))
                    {
                        if (dbImage.UpdateDate > DateTime.Now.Add(-TimeSpan.FromMinutes(30)))
                        {
                            ImageCache.AddImage(imageName, dbImage.Data);
                            return dbImage.Data;
                        }
                        else
                        {
                            return await UpdateImage(imageRepository.UpdateImage, id, name, dbImage.Data);
                        }
                    }
                    else
                    {
                        return await UpdateImage(imageRepository.CreateImage, id, name, new byte[0]);
                    }
                }
            }

            return new byte[0];
        }

        private bool IsImageInBase(string imageName, out IImage image)
        {
            image = imageRepository.GetImageByName(imageName)!;
            return image != null;
        }

        private string GetImageName(int? id, string? name) => id + "_image_" + name;

        private async Task<byte[]> UpdateImage(Func<IImage, bool> func, int? id, string? name, byte[] defaultData)
        {
            var imageName = GetImageName(id, name);
            var image = await GetImageFromSite(id, name);
            if (image.Length > 0)
            {
                ImageCache.AddImage(imageName, image);
                func(new Image()
                {
                    Data = image,
                    Name = imageName,
                    UpdateDate = DateTime.Now
                });
                return image;
            }
            else
            {
                return defaultData;
            }
        }

        public async Task<byte[]> GetImageFromSite(int? id, string? name)
        {
            using HttpClient client = new HttpClient();

            try
            {
                using var responce = await client.GetAsync($"https://i.dummyjson.com/data/products/{id}/{name}");

                if (responce != null && responce.IsSuccessStatusCode)
                {
                    return await responce.Content.ReadAsByteArrayAsync();
                }
            }
            catch (Exception ex)
            {

            }

            return new byte[0];
        }
    }
}