using API.Entities;
using API.Models.Base;
using API.Models.Users;

namespace API.Interface
{
    public interface IUsersRepository
    {
        public Task<List<User>> GetUsers(int pageNumber = 1);

        public Task<User> GetUser(string ikNumber);

        public Task<Base> PutUser(PutUserRequest userRequest, string ikNumber);

        public Task<Base> DeleteUser(string ikNumber);

        public Task<User> EnableDisableUser(string state, string iKNumber = null);
    }
}
