namespace API.Models.Base
{
    public class BasePaginationResponse<T> : BaseResponse
    {
        public PaginationResults PaginationResults { get; set; }

        public List<T> Results { get; set; }
    }
}
