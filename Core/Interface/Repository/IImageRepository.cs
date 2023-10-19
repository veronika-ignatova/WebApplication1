using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Interface.Repository
{
    public interface IImageRepository
    {
        IImage? GetImageByName(string name);
        public bool CreateImage(IImage image);
        bool UpdateImage(IImage image);
    }
}
