using API.Entities;
using API.Interface;
using API.Models.Resource;
using MySqlConnector;

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
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", tenantId),
                    new MySqlParameter("sClientId", clientId)
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
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", clientRequest.TenantId),
                    new MySqlParameter("sClientId", clientRequest.ClientId),
                    new MySqlParameter("sKey", clientRequest.Key),
                    new MySqlParameter("sValue", clientRequest.Value),
                    new MySqlParameter("sLanguage", clientRequest.Language),
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
