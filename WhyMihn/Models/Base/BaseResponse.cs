namespace API.Models.Base
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(bool hasErrors)
        {
            HasErrors = hasErrors;
            Errors = new List<BaseError>();
        }

        public void AddError(string message, Guid? stacktrace = null)
        {
            Errors.Add(new BaseError(message, stacktrace));
        }

        public bool HasErrors { get; set; }

        public List<BaseError> Errors { get; set; }
    }
}
