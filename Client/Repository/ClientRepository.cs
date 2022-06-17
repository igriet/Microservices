using Client.Interface;

namespace Client.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Models.Client> _clients = new List<Models.Client>();

        public ClientRepository()
        {
            _clients.Add(new Models.Client() { Id = "1", Name = "Igriet", City = "CDMX" });
            _clients.Add(new Models.Client() { Id = "2", Name = "Carla", City = "Xalapa" });
            _clients.Add(new Models.Client() { Id = "3", Name = "Eliseo", City = "Toluca" });
            _clients.Add(new Models.Client() { Id = "4", Name = "Edith", City = "Tampico" });
            _clients.Add(new Models.Client() { Id = "5", Name = "Tere", City = "Puebla" });
        }

        public Task<Models.Client> GetAsync(string id)
        {
            var client = _clients.FirstOrDefault(c => c.Id.Equals(id));
            return Task.FromResult(client);
        }
    }
}
