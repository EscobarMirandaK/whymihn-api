using API.Entities;
using API.Extensions;
using API.Interface;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public DashboardRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
        }

        public async Task<Dashboard> GetDashboard(User user)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserIDNumber", user.Email)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Dashboard>("SP_WHYMIHN_API_GET_DASHBOARD_BY_EMAIL", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
