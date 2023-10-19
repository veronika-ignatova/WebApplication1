using Core.Entities;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BootCampWeb.Pages
{
    public class ProductModel : PageModel
    {
        protected readonly IProductService _productService;

        public ProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product? Product { get; set; }
        public async Task OnGetAsync(int id)
        {
            Product = await _productService.GetProductByIdAsync(id);
        }
    }
}
