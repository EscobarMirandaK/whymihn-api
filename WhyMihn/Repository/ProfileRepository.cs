using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Profile;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IDatabaseHelper databaseHelper;
        private readonly IConfiguration configuration;

        public ProfileRepository(IDatabaseHelper databaseHelper, IConfiguration configuration)
        {
            this.databaseHelper = databaseHelper;
            this.configuration = configuration;
        }

        public async Task<Profile> GetProfile(User user)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("UserIDNumber", user.Email)
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Profile>("SP_WHYMIHN_API_GET_USER_BY_EMAIL", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Base> PutProfile(PutProfileRequest profileRequest, string ikNumber)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("IKNumber", ikNumber),
                    new SqlParameter("FirstName", profileRequest.Name),
                    new SqlParameter("LastName", profileRequest.LastName),
                    new SqlParameter("SecondLastName", profileRequest.SecondLastName),
                    new SqlParameter("IdType", profileRequest.IdType),
                    new SqlParameter("Identification", profileRequest.IdValue),
                    new SqlParameter("Email", profileRequest.Email),
                    new SqlParameter("Phone", profileRequest.Phone),
                    new SqlParameter("Country", profileRequest.Country),
                    new SqlParameter("Province", profileRequest.Province),
                    new SqlParameter("Canton", profileRequest.Canton),
                    new SqlParameter("District", profileRequest.District),
                    new SqlParameter("DeliveryAddress", profileRequest.Address),
                };
                var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMIHN_API_UPDATE_PROFILE", parameters);
                return results.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
