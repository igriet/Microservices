using Sale.Models;

namespace Sale.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAsync(string clientId);
    }
}
