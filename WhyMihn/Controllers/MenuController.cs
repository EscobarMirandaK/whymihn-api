using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Menu;
using API.Models.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public IMenuRepository menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        [Authorize(Role.ADMIN)]
        [Route("GetMenu/{menuId}/{tenantId}/{clientId}")]
        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetMenu(string menuId, string tenantId, string clientId)
        {
            return await this.menuRepository.GetMenu(menuId, tenantId, clientId);
        }

        [Authorize(Role.ADMIN)]
        [Route("GetMenuWithParent/{menuId}/{tenantId}/{clientId}/{parentId}")]
        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetMenuWithParent(string menuId, string tenantId, string clientId, string parentId)
        {
            return await this.menuRepository.GetMenuWithParent(menuId, tenantId, clientId, parentId);
        }

        [Authorize(Role.ADMIN)]
        [Route("AddMenu")]
        [HttpPost]
        public async Task<ActionResult<Menu>> AddMenu(AddMenuRequest addParameterRequest)
        {
            var result = await this.menuRepository.AddMenu(addParameterRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("UpdateMenu")]
        [HttpPut]
        public async Task<ActionResult<Menu>> UpdateMenu(UpdateMenuRequest updateParameterRequest)
        {
            var result = await this.menuRepository.UpdateMenu(updateParameterRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("DeleteMenu/{menuId}/{tenantId}/{clientId}")]
        [HttpDelete]
        public async Task<ActionResult<Menu>> DeleteMenu(string menuId,string tenantId, string clientId)
        {
            var result = await this.menuRepository.DeleteMenu(menuId, tenantId, clientId);

            return Ok(result);
        }
    }
}
