using Core.Entities;

namespace Core.Interface.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<IEnumerable<Product>> GetProductFromSearch(string search);
        Task<Product> GetProductByIdAsync(int id);
    }
}
