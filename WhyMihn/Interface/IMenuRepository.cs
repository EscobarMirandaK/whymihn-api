using API.Entities;
using API.Extensions;
using API.Models.Menu;
using API.Models.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace API.Interface
{
    public interface IMenuRepository
    {

        public  Task<ActionResult<Menu>> GetMenu(string menuId, string tenantId, string clientId);

        public  Task<ActionResult<Menu>> GetMenuWithParent(string menuId, string tenantId, string clientId, string parentId);

        public  Task<ActionResult<Base>> AddMenu(AddMenuRequest addParameterRequest);

        public  Task<ActionResult<Base>> UpdateMenu(UpdateMenuRequest updateParameterRequest);

        public  Task<ActionResult<Base>> DeleteMenu(string menuId, string tenantId, string clientId);
    }
}
