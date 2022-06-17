using Newtonsoft.Json;
using Search.Interface;
using Search.Models;

namespace Search.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("productService");

            var response = await httpClient.GetAsync($"api/product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);

                return product;
            }

            return null;
        }
    }
}
