using Product.Interface;

namespace Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Models.Product> _products = new List<Models.Product>();
        public ProductRepository()
        {
            for(int i = 0; i < 100; i++)
            {
                _products.Add(new Models.Product()
                {
                    Id = (i+1).ToString(),
                    Name = $"Producto {i + 1}",
                    Price = (i+1) * 3.14
                });
            }
        }
        public Task<Models.Product> GetAsync(string id)
        {
            var product = _products.FirstOrDefault(p => p.Id.Equals(id));
            return Task.FromResult(product);
        }
    }
}
