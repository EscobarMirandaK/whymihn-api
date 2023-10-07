using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Parameter;
using API.Models.Password;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace API.Repository
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public ParameterRepository(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }
        public async Task<List<Parameter>> GetParameter(string parameterId, string tableName, string tenantId, string clientId)
        {

            MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", tenantId),
                    new MySqlParameter("sClientId", clientId), // 1 as default page to reuse the stored procedure
                    new MySqlParameter("sParameterId", parameterId),
                    new MySqlParameter("sTableName", tableName)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Parameter>("SP_WHYMINH_API_GET_PARAMETER", parameters);
            return results;

        }

      public  async Task<ActionResult<Base>> AddParameter(AddParameterRequest request)
        {
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", request.TenantId),
                    new MySqlParameter("sClientId", request.ClientId),
                    new MySqlParameter("sParameterId", request.ParameterId),
                    new MySqlParameter("sTableName", request.TableName),
                    new MySqlParameter("sParameterValue", request.ParameterValue)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_ADD_PARAMETER", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdateParameter(UpdateParameterRequest request)
        {
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", request.TenantId),
                    new MySqlParameter("sClientId", request.ClientId),
                    new MySqlParameter("sParameterId", request.ParameterId),
                    new MySqlParameter("sTableName", request.TableName),
                    new MySqlParameter("sParameterValue", request.ParameterValue)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_UPDATE_PARAMETER", parameters);
            return results.FirstOrDefault();

        }

        public async Task<ActionResult<Base>> DeleteParameter(string parameterId, string tableName, string tenantId, string clientId)
        {
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("sTenantId", tenantId),
                    new MySqlParameter("sClientId", clientId), 
                    new MySqlParameter("sParameterId", parameterId),
                    new MySqlParameter("sTableName", tableName)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_DELETE_PARAMETER", parameters);
            return results.FirstOrDefault();
        }
    }
}
