using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Resource;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("resource")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceRepository resourceRepository;

        public ResourceController(IResourceRepository resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        [Authorize(Role.ADMIN)]
        [HttpGet]
        [Route("{tenantId?}/{clientId?}")]
        public async Task<ActionResult<List<Resource>>> Get(string tenantId = "All", string clientId = "All")
        {
            return await this.resourceRepository.GetResources(tenantId, clientId);
        }

        [Authorize(Role.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<Resource>> Create([FromBody] ResourceRequest resourceRequest)
        {
            return await this.resourceRepository.CreateOrUpdate(resourceRequest);
        }

        [Authorize(Role.ADMIN)]
        [HttpPut]
        public async Task<ActionResult<Resource>> Update([FromBody] ResourceRequest resourceRequest)
        {
            return await this.resourceRepository.CreateOrUpdate(resourceRequest);
        }
    }
}
