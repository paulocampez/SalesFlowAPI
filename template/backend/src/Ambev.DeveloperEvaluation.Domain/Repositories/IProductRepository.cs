using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<List<Product>> GetProductsAsync();
        Task CreateProductAsync(Product product);
    }
}
