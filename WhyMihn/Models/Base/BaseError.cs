namespace API.Models.Base
{
    public class BaseError
    {
        public BaseError(string message, Guid? stacktraceId)
        {
            Message = message;
            StacktraceId = stacktraceId;
        }

        public string Message { get; set; }

        public Guid? StacktraceId { get; set; }
    }
}
