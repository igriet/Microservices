using Newtonsoft.Json;
using Search.Interface;
using Search.Models;

namespace Search.Services
{
    public class ClientService : IClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Client> GetClientAsync(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("clientService");
            var response = await httpClient.GetAsync($"api/client/{id}");

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var client = JsonConvert.DeserializeObject<Client>(content);

                return client;
            }

            return null;
        } 
    }
}
