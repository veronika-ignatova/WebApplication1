using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class ImagesModel : PageModel
    {
        protected readonly IImageService imageService;
        public ImagesModel(IImageService imageService) 
        {
            this.imageService = imageService;
        }

        public async Task<IActionResult> OnGet(int? id, string? name)
        {
            var byteArr = await imageService.GetImage(id, name);

            return File(byteArr, $"image/{name.Split(".").Last()}");
        }
    }
}
