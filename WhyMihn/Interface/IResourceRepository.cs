using API.Entities;
using API.Models.Resource;

namespace API.Interface
{
    public interface IResourceRepository
    {
        public Task<List<Resource>> GetResources(string tenantId, string clientId);

        public Task<Resource> CreateOrUpdate(ResourceRequest client);
    }
}
