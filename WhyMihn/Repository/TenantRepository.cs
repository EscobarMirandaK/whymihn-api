using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Tenant;
using API.Models.Users;
using Microsoft.Data.SqlClient;
using MySqlConnector;

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
                MySqlParameter[] parameters = null;
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
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", tenantRequest.TenantId),
                    new MySqlParameter("sName", tenantRequest.Name),
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
