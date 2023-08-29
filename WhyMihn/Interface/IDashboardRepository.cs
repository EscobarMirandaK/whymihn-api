using API.Entities;

namespace API.Interface
{
    public interface IDashboardRepository
    {
        public Task<Dashboard> GetDashboard(User user);
    }
}
