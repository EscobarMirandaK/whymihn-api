using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Client;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [Authorize(Role.ADMIN)]
        [HttpGet]
        [Route("{tenantId?}")]
        public async Task<ActionResult<List<Client>>> Get(string tenantId = "All")
        {
            return await this.clientRepository.GetClients(tenantId);
        }

        [Authorize(Role.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<Client>> Create([FromBody] ClientRequest clientRequest)
        {
            return await this.clientRepository.CreateOrUpdate(clientRequest);
        }

        [Authorize(Role.ADMIN)]
        [HttpPut]
        public async Task<ActionResult<Client>> Update([FromBody] ClientRequest clientRequest)
        {
            return await this.clientRepository.CreateOrUpdate(clientRequest);
        }
    }
}
