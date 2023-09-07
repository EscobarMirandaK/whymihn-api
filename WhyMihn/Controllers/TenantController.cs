using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Base;
using API.Models.Tenant;
using API.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("tenant")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantRepository tenantRepository;

        public TenantController(ITenantRepository tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        [Authorize(Role.ADMIN)]
        [HttpGet]
        public async Task<ActionResult<List<Tenant>>> Get()
        {
            return await this.tenantRepository.GetTenants();
        }

        [Authorize(Role.ADMIN)]
        [HttpPost]
        public async Task<ActionResult<Tenant>> Create([FromBody] TenantRequest tenantRequest)
        {
            return await this.tenantRepository.CreateOrUpdate(tenantRequest);
        }

        [Authorize(Role.ADMIN)]
        [HttpPut]
        public async Task<ActionResult<Tenant>> Update([FromBody] TenantRequest tenantRequest)
        {
            return await this.tenantRepository.CreateOrUpdate(tenantRequest);
        }
    }
}
