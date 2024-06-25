using API.Entities;
using API.Interface;
using API.Models.Tenant;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public TenantRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
        }

        public async Task<List<Tenant>> GetTenants()
        {
            try
            {
                SqlParameter[] parameters = null;
                var results = await this.databaseHelper.ExecuteStoredProcedure<Tenant>("SP_WHYMIHN_API_GET_TENANTS", parameters);
                return results;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tenant> CreateOrUpdate(TenantRequest tenantRequest)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantRequest.TenantId),
                    new SqlParameter("sName", tenantRequest.Name),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Tenant>("SP_WHYMIHN_API_CREATE_UPDATE_TENANT", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
