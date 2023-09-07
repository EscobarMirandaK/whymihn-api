using API.Interface;
using API.Models;
using API.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API.Extensions
{
    public class DatabaseHelper : IDatabaseHelper
    {
        readonly DatabaseContext _dbContext;

        public DatabaseHelper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> ExecuteStoredProcedure<T>(string storedProcedure, Array parameters)
        where T : new ()
        {
            T item = new();

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                _dbContext.Database.OpenConnection();

                using (var result = command.ExecuteReaderAsync())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(await result);
                    List<T> results = dataTable.AsEnumerable().Select(m => ConvertExtension.ToObject<T>(m)).ToList();
                    return results;
                }
            }
        }

        public async Task<BasePaginationResponse<T>> ExecuteStoredProcedureWithPagination<T>(string storedProcedure, Array parameters)
        where T : new()
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                _dbContext.Database.OpenConnection();

                BasePaginationResponse<T> response = new BasePaginationResponse<T>();
                using (var reader = command.ExecuteReaderAsync())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(await reader);
                    var dataTable2 = new DataTable();
                    dataTable2.Load(await reader);

                    var paginationResults = dataTable.AsEnumerable().Select(m => ConvertExtension.ToObject<PaginationResults>(m)).ToList();
                    var results = dataTable2.AsEnumerable().Select(m => ConvertExtension.ToObject<T>(m)).ToList();
                    response.PaginationResults = paginationResults.FirstOrDefault();
                    response.Results = results;
                }

                return response;
            }
        }
    }
}
