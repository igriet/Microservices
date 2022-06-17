namespace Product.Interface
{
    public interface IProductRepository
    {
        Task<Product.Models.Product> GetAsync(string id);
    }
}
