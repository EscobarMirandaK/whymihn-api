using API.Entities;
using API.Interface;
using API.Models.Resource;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public ResourceRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
        }

        public async Task<List<Resource>> GetResources(string tenantId, string clientId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Resource>("SP_WHYMIHN_API_GET_RESOURCES", parameters);
                return results;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Resource> CreateOrUpdate(ResourceRequest clientRequest)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", clientRequest.TenantId),
                    new SqlParameter("sClientId", clientRequest.ClientId),
                    new SqlParameter("sKey", clientRequest.Key),
                    new SqlParameter("sValue", clientRequest.Value),
                    new SqlParameter("sLanguage", clientRequest.Language),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Resource>("SP_WHYMIHN_API_CREATE_UPDATE_RESOURCE", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
