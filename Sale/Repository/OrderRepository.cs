using Sale.Interface;
using Sale.Models;

namespace Sale.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public OrderRepository()
        {
            _orders.Add(new Order()
            {
                Id = "0001",
                OrderDate = DateTime.Now.AddMonths(-1),
                ClientId = "1",
                Total = 100,
                Items = new List<OrderItem>()
                 {
                     new OrderItem(){ OrderId="0001", Id=1, Price=50, ProductId="23", Quantity=2},
                     new OrderItem(){ OrderId="0001", Id=2, Price=50, ProductId="12", Quantity=2}
                 }
            });
            _orders.Add(new Order()
            {
                Id = "0002",
                OrderDate = DateTime.Now.AddMonths(-1),
                ClientId = "2",
                Total = 100,
                Items = new List<OrderItem>()
                 {
                     new OrderItem(){ OrderId="0002", Id=1, Price=50, ProductId="90", Quantity=4},
                     new OrderItem(){ OrderId="0002", Id=2, Price=50, ProductId="80", Quantity=4}
                 }
            });
            _orders.Add(new Order()
            {
                Id = "0003",
                OrderDate = DateTime.Now.AddMonths(-1),
                ClientId = "3",
                Total = 100,
                Items = new List<OrderItem>()
                 {
                     new OrderItem(){ OrderId="0003", Id=1, Price=25, ProductId="1", Quantity=1},
                     new OrderItem(){ OrderId="0003", Id=2, Price=25, ProductId="11", Quantity=1},
                     new OrderItem(){ OrderId="0003", Id=3, Price=25, ProductId="21", Quantity=1},
                     new OrderItem(){ OrderId="0003", Id=4, Price=25, ProductId="31", Quantity=1}
                 }
            });
            _orders.Add(new Order()
            {
                Id = "0004",
                OrderDate = DateTime.Now.AddMonths(-1),
                ClientId = "4",
                Total = 100,
                Items = new List<OrderItem>()
                 {
                     new OrderItem(){ OrderId="0004", Id=1, Price=33.3, ProductId="22", Quantity=1},
                     new OrderItem(){ OrderId="0004", Id=2, Price=33.3, ProductId="33", Quantity=1},
                     new OrderItem(){ OrderId="0004", Id=3, Price=33.3, ProductId="44", Quantity=1},
                 }
            });
        }
        public Task<IEnumerable<Order>> GetAsync(string clientId)
        {
            var orders= _orders.Where(c => c.ClientId.Equals(clientId));
            return Task.FromResult(orders);
        }
    }
}
