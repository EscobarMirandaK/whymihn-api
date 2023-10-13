using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Users;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDatabaseHelper databaseHelper;
        private readonly IConfiguration configuration;

        public UsersRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
            this.configuration = configuration;
        }

        public async Task<List<User>> GetUsers(int pageNumber = 1)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("PageNumber", pageNumber),
                    new SqlParameter("PageSize", int.Parse(configuration[Pagination.AllRecords]))
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<User>("SP_WHYMIHN_API_GET_USERS", parameters);
                return results;
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetUser(string ikNumber)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IKNumber", ikNumber),
                    new SqlParameter("PageNumber", 1), // 1 as default page to reuse the stored procedure
                    new SqlParameter("PageSize", int.Parse(configuration[Pagination.PageSize]))
                };
                var results = await this.databaseHelper.ExecuteStoredProcedureWithPagination<User>("SP_WHYMIHN_API_GET_USERS", parameters);
                return results.Results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Base> PutUser(PutUserRequest userRequest, string ikNumber)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IKNumber", ikNumber),
                    new SqlParameter("FirstName", userRequest.FirstName),
                    new SqlParameter("LastName", userRequest.LastName),
                    new SqlParameter("SecondLastName", userRequest.SecondLastName),
                    new SqlParameter("IdType", userRequest.IdType),
                    new SqlParameter("Identification", userRequest.Identification),
                    new SqlParameter("Email", userRequest.Email),
                    new SqlParameter("Phone", userRequest.Phone),
                    new SqlParameter("Country", userRequest.Country),
                    new SqlParameter("Province", userRequest.Province),
                    new SqlParameter("Canton", userRequest.Canton),
                    new SqlParameter("District", userRequest.District),
                    new SqlParameter("DeliveryAddress", userRequest.DeliveryAddress),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMIHN_API_UPDATE_PROFILE", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Base> DeleteUser(string iKNumber = null)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IKNumber", iKNumber),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMIHN_API_DELETE_USER", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> EnableDisableUser(string state, string iKNumber = null)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IKNumber", iKNumber),
                    new SqlParameter("sState", state)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<User>("SP_WHYMIHN_API_ENABLE_DISABLE_USER", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
