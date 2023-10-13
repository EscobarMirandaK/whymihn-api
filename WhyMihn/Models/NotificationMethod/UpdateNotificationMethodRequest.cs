namespace API.Models.NotificationMethod
{
    public class UpdateNotificationMethodRequest
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string NotificationMethodId { get; set; }
        public string Name { get; set; }
    }
}
