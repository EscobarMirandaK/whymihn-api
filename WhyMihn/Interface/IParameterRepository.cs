using API.Entities;
using API.Models.Parameter;
using API.Models.Password;
using Microsoft.AspNetCore.Mvc;

namespace API.Interface
{
    public interface IParameterRepository
    {

        public Task<List<Parameter>> GetParameter(string parameterId, string tableName, string tenantId, string clientId);

        public Task<ActionResult<Base>> AddParameter(AddParameterRequest request);

        public Task<ActionResult<Base>> UpdateParameter(UpdateParameterRequest request);
        public Task<ActionResult<Base>> DeleteParameter(string parameterId, string tableName, string tenantId, string clientId);
    }
}
