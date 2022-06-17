namespace Client.Interface
{
    public interface IClientRepository
    {
        Task<Models.Client> GetAsync(string id);
    }
}
