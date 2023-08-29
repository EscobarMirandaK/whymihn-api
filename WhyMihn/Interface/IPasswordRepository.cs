using API.Entities;
using API.Models.Password;

namespace API.Interface
{
    public interface IPasswordRepository
    {
        public Task<Base> ChangePassword(PutChangePasswordRequest changePassword, string userName);

        public Task<Base> ResetPassword(string userName, string password);
    }
}
