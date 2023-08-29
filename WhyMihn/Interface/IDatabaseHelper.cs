using API.Models.Base;

namespace API.Interface
{
    public interface IDatabaseHelper
    {
        public Task<List<T>> ExecuteStoredProcedure<T>(string storedProcedure, Array parameters) where T : new();

        public Task<BasePaginationResponse<T>> ExecuteStoredProcedureWithPagination<T>(string storedProcedure, Array parameters) where T : new();
    }
}
