using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Parameter;
using API.Models.Password;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("parameter")]
    [ApiController]
    public class ParameterController : ControllerBase
    {

        public IParameterRepository parameterRepository;
    
    public ParameterController(IParameterRepository parameterRepository) 
        { 
        this.parameterRepository = parameterRepository;
        }

        [Authorize(Role.ADMIN)]
        [Route("GetParameter/{parameterId}/{tableName}/{tenantId}/{clientId}")]
        [HttpGet]
        public async Task<ActionResult<Parameter>> GetParameter(string parameterId,string tableName, string tenantId, string clientId)
        {   
            return await this.parameterRepository.GetParameter(parameterId,tableName,tenantId,clientId);
        }

        [Authorize(Role.ADMIN)]
        [Route("AddParameter")]
        [HttpPost]
        public async Task<ActionResult<Parameter>> AddParameter(AddParameterRequest addParameterRequest)
        {
            var result = await this.parameterRepository.AddParameter(addParameterRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("UpdateParameter")]
        [HttpPut]
        public async Task<ActionResult<Parameter>> UpdateParameter(UpdateParameterRequest updateParameterRequest)
        {
            var result = await this.parameterRepository.UpdateParameter(updateParameterRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("DeleteParameter/{parameterId}/{tableName}/{tenantId}/{clientId}")]
        [HttpDelete]
        public async Task<ActionResult<Parameter>> DeleteParameter(string parameterId, string tableName, string tenantId, string clientId)
        {
            var result = await this.parameterRepository.DeleteParameter(parameterId, tableName, tenantId, clientId);

            return Ok(result);
        }
    }
}
