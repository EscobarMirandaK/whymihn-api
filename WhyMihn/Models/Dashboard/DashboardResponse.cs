using API.Models.Base;

namespace API.Models.Dashboard
{
    public class DashboardResponse : BaseResponse
    {
        public DashboardResponse()
        {
        }

        public DashboardResponse(bool hasErrors) : base(hasErrors)
        {
        }

        public string IdClient { get; set; }

        public string Name { get; set; }

        public bool Admin { get; set; }
    }
}
