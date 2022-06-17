using Search.Models;

namespace Search.Interface
{
    public interface IClientService
    {
        Task<Client> GetClientAsync(string id);
    }
}
