using Core.Entities;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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


        public async Task<IActionResult> OnGet()
        {

            Products = await _productService.GetAllProductAsync();

            return Page();
        }
    }
}
