using Core.Entities;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class ProductsModel : PageModel
    {
        protected readonly IProductService _productService;

        public ProductsModel(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product?> Products { get; set; }


        public async Task<IActionResult> OnGet(string searchString)
        {
            if (String.IsNullOrEmpty(searchString) || searchString.Length < 3)
            {
                Products = await _productService.GetAllProductAsync();
            }
            else
            {
                Products = await _productService.GetProductFromSearch(searchString);
            }
            return Page();
        }
    }
}
