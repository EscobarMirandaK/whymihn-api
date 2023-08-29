using API.Entities;
using API.Models.Login;
using API.Models.Register;

namespace API.Interface
{
    public interface IAuthRepository
    {
        public Task<User> Login(LoginRequest loginRequest);

        public Task<User> Register(RegisterRequest registerRequest);
    }
}
