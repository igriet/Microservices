using Search.Models;

namespace Search.Interface
{
    public interface ISaleService
    {
        Task<IEnumerable<Order>> GetSaleAsync(string clientId);
    }
}
