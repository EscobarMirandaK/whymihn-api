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
        public async Task<Parameter> GetParameter(string parameterId, string tableName, string tenantId, string clientId)
        {

            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", tenantId),
                    new SqlParameter("p_client_id", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("p_parameter_id", parameterId),
                    new SqlParameter("p_table_name", tableName)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedureWithPagination<Parameter>("SP_WHYMINH_Get_Parameter", parameters);
            return results.Results.FirstOrDefault();

        }

      public  async Task<ActionResult<Base>> AddParameter(AddParameterRequest request)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", ""),
                    new SqlParameter("p_client_id", ""),
                    new SqlParameter("p_parameter_id", ""),
                    new SqlParameter("p_table_name", ""),
                    new SqlParameter("p_parameter_value", "")
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_Add_Parameter", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdateParameter(UpdateParameterRequest request)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", request.TenantId),
                    new SqlParameter("p_client_id", request.ClientId),
                    new SqlParameter("p_parameter_id", request.ParameterId),
                    new SqlParameter("p_table_name", request.TableName),
                    new SqlParameter("p_parameter_value", request.ParameterValue)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_Update_Parameter", parameters);
            return results.FirstOrDefault();

        }

        public async Task<ActionResult<Base>> DeleteParameter(string parameterId, string tableName, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", tenantId),
                    new SqlParameter("p_client_id", clientId), 
                    new SqlParameter("p_parameter_id", parameterId),
                    new SqlParameter("p_table_name", tableName)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_Delete_Parameter", parameters);
            return results.FirstOrDefault();
        }
    }
}
