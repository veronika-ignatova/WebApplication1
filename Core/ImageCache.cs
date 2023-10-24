
namespace Core
{
    public static class ImageCache
    {
        private static Dictionary<string, CasheElement<byte[]>> images;
        private static object lockObj = new object();

        static ImageCache()
        {
            images = new Dictionary<string, CasheElement<byte[]>>();
        }

        public static byte[] GetImages(string key)
        {
            return GetPrivateImage(key) ?? new byte[0];
        }

        public static void AddImage(string key, byte[] image, DateTime expiredDate)
        {
            if (!images.ContainsKey(key))
            {
                lock (lockObj)
                {
                    images.Add(key, new CasheElement<byte[]> { Value = image, ExpiredDate = expiredDate });
                }
            }
        }

        public static bool IsImageDownload(string key)
        {
            return GetPrivateImage(key) != null;
        }

        public static bool IsImageDownload(string key, out byte[]? image)
        {
            image = GetPrivateImage(key);
            return image != null;
        }

        private static byte[]? GetPrivateImage(string key)
        {
            var element = images.GetValueOrDefault(key, null);

            if (element == null) return null;
            else
            {
                if (element.ExpiredDate < DateTime.Now)
                {
                    lock (lockObj)
                    {
                        images.Remove(key);
                    }
                    return null;
                }
            }
            return element.Value;
        }
    }

    public class CasheElement<T>
    {
        public T Value { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}