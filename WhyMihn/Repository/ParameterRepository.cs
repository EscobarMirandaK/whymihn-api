using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Parameter;
using API.Models.Password;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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

            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("sParameterId", parameterId),
                    new SqlParameter("sTableName", tableName)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Parameter>("SP_WHYMINH_API_GET_PARAMETER", parameters);
            return results;

        }

      public  async Task<ActionResult<Base>> AddParameter(AddParameterRequest request)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", request.TenantId),
                    new SqlParameter("sClientId", request.ClientId),
                    new SqlParameter("sParameterId", request.ParameterId),
                    new SqlParameter("sTableName", request.TableName),
                    new SqlParameter("sParameterValue", request.ParameterValue)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_ADD_PARAMETER", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdateParameter(UpdateParameterRequest request)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", request.TenantId),
                    new SqlParameter("sClientId", request.ClientId),
                    new SqlParameter("sParameterId", request.ParameterId),
                    new SqlParameter("sTableName", request.TableName),
                    new SqlParameter("sParameterValue", request.ParameterValue)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_UPDATE_PARAMETER", parameters);
            return results.FirstOrDefault();

        }

        public async Task<ActionResult<Base>> DeleteParameter(string parameterId, string tableName, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId), 
                    new SqlParameter("sParameterId", parameterId),
                    new SqlParameter("sTableName", tableName)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_DELETE_PARAMETER", parameters);
            return results.FirstOrDefault();
        }
    }
}
