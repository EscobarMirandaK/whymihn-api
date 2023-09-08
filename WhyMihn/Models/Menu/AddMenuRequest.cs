namespace API.Models.Menu
{
    public class AddMenuRequest
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string MenuId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Url { get; set; }
    }
}
