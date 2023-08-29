using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Password;
using API.Models.Profile;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly IDatabaseHelper databaseHelper;
        private readonly IConfiguration configuration;

        public PasswordRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
            this.configuration = configuration;
        }

        public async Task<Base> ChangePassword(PutChangePasswordRequest changePassword, string userName)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserName", changePassword.Email),
                    new SqlParameter("OldPassword", changePassword.OldPassword),
                    new SqlParameter("NewPassword", changePassword.Password),
                    new SqlParameter("IKNumber", userName)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMIHN_API_PASSWORD_CHANGE", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Base> ResetPassword(string userName, string password)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserName", userName),
                    new SqlParameter("Password", password)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMIHN_API_PASSWORD_RESET", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
