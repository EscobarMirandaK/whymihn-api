using API.Entities;
using API.Interface;
using API.Models.Client;
using MySqlConnector;

namespace API.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public ClientRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
        }

        public async Task<List<Client>> GetClients(string tenantId)
        {
            try
            {
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", tenantId)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Client>("SP_WHYMIHN_API_GET_CLIENTS", parameters);
                return results;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Client> CreateOrUpdate(ClientRequest clientRequest)
        {
            try
            {
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", clientRequest.TenantId),
                    new MySqlParameter("sClientId", clientRequest.ClientId),
                    new MySqlParameter("sName", clientRequest.Name),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Client>("SP_WHYMIHN_API_CREATE_UPDATE_CLIENT", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
