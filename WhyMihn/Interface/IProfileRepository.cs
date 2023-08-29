using API.Entities;
using API.Models.Profile;

namespace API.Interface
{
    public interface IProfileRepository
    {
        public Task<Profile> GetProfile(User user);

        public Task<Base> PutProfile(PutProfileRequest profileRequest, string ikNumber);
    }
}
