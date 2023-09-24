using API.Entities;
using API.Interface;
using API.Models.Login;
using API.Models.Register;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace API.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public AuthRepository(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public async Task<User> Login(LoginRequest loginRequest)
        {
            try
            {
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("sEmail", loginRequest.Email),
                    new MySqlParameter("sPassword", loginRequest.Password)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<User>("SP_WHYMIHN_API_LOGIN", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> Register(RegisterRequest registerRequest)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserName", registerRequest.IdValue),
                    new SqlParameter("Email", registerRequest.Email),
                    new SqlParameter("IdType", registerRequest.IdType),
                    new SqlParameter("Id", registerRequest.IdValue),
                    new SqlParameter("FullName", $"{registerRequest.Name} {registerRequest.LastName} {registerRequest.SecondLastName}"),
                    new SqlParameter("Password", registerRequest.Password),
                    new SqlParameter("Genre", registerRequest.Genre),
                    new SqlParameter("MobilePhone", registerRequest.PhoneNumber),
                    new SqlParameter("Phone", registerRequest.PhoneNumber),
                    new SqlParameter("Country", registerRequest.Country),
                    new SqlParameter("Province", registerRequest.Province),
                    new SqlParameter("Canton", registerRequest.Canton),
                    new SqlParameter("District", registerRequest.District),
                    new SqlParameter("DeliveryAddress", registerRequest.AddressArea),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<User>("SP_WHYMIHN_API_REGISTER", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
