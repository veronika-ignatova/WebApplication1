using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BootCampWeb.Pages
{
    public class ProductsModel : PageModel
    {
        public class Product
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public double DiscountPercentage { get; set; }
            public double Rating { get; set; }
            public int Stock { get; set; }
            public string Brand { get; set; }
            public string Category { get; set; }
            public string Thumbnail { get; set; }
            public List<string> Images { get; set; }
        }

        public class MyProducts
        {
            public List<Product> Products { get; set; }
            public int Total { get; set; }
            public int Skip { get; set; }
            public int Limit { get; set; }
        }

        public MyProducts? Products { get; set; }

        public async Task OnGet()
        {
            using (var client = new HttpClient())
            {
                using (var responce = await client.GetAsync("https://dummyjson.com/products"))
                {
                    var strJSON = await responce.Content.ReadAsStringAsync();
                    Products = JsonSerializer.Deserialize<MyProducts>(strJSON, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    });

                }
            }
        }
    }
}
