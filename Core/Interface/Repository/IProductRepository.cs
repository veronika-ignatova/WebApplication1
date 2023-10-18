using Core.Entities;

namespace Core.Interface.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
    }
}
