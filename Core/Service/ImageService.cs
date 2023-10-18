using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ImageService : IImageService
    {
        public async Task<byte[]> GetImage(int? id, string? name)
        {
            if (!string.IsNullOrEmpty(name) && id.HasValue && id.Value != 0)
            {
                var imageName = id + "_image_" + name;

                if (ImageCache.IsImageDownload(imageName))
                {
                    return ImageCache.GetImages(imageName);
                }
                else
                {
                    var image = await GetImageFromSite(id, name);
                    if (image.Length > 0)
                    {
                        ImageCache.AddImage(imageName, image);
                        return image;
                    }
                }
            }

            return new byte[0];
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
