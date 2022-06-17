using Search.Models;

namespace Search.Interface
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(string id);
    }
}
