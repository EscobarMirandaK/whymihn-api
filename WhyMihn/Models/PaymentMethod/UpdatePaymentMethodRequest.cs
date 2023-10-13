namespace API.Models.PaymentMethod
{
    public class UpdatePaymentMethodRequest
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string PaymentMethodId { get; set; }
        public string Name { get; set; }
    }
}
