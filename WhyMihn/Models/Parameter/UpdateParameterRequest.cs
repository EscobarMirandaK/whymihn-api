namespace API.Models.Parameter
{
    public class UpdateParameterRequest
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ParameterId { get; set; }
        public string TableName { get; set; }
        public string ParameterValue { get; set; }

    }
}
