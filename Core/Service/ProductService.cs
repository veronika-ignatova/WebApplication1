using Core.Entities;
using Core.Interface.Repository;
using Core.Interface.Service;

namespace Core.Service
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await productRepository.GetAllProductAsync();
        }
        public async Task<IEnumerable<Product>> GetProductFromSearch(string search)
        {
            var results = await GetAllProductAsync();

            if (!String.IsNullOrEmpty(search))
            {
                results = results.Where(x => x.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || x.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            return results;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return (await GetAllProductAsync()).FirstOrDefault(x => x.Id == id);
        }
    }
}
