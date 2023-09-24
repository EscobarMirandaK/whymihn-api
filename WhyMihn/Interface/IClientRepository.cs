using API.Entities;
using API.Models.Client;

namespace API.Interface
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetClients(string tenantId);

        public Task<Client> CreateOrUpdate(ClientRequest client);
    }
}
