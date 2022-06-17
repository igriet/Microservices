using Newtonsoft.Json;
using Search.Interface;
using Search.Models;

namespace Search.Services
{
    public class SaleService : ISaleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SaleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Order>> GetSaleAsync(string clientId)
        {
            var httpClient = _httpClientFactory.CreateClient("saleService");
            var response = await httpClient.GetAsync($"api/sale/{clientId}");

            if (response.IsSuccessStatusCode)
            {
                var content =await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<IEnumerable<Order>>(content);

                return order;
            }
            return null;
        }
    }
}
