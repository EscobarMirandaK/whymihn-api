using API.Entities;
using API.Models.Tenant;

namespace API.Interface
{
    public interface ITenantRepository
    {
        public Task<List<Tenant>> GetTenants();

        public Task<Tenant> CreateOrUpdate(TenantRequest tenant);
    }
}
