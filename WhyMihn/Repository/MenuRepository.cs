using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Menu;
using API.Models.Parameter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public MenuRepository(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }
        public async Task<ActionResult<List<Menu>>> GetMenu(string menuId, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("sMenuId", menuId),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Menu>("SP_WHYMINH_API_GET_MENU", parameters);
            return results;
        }

        public async Task<ActionResult<List<Menu>>> GetMenuWithParent(string menuId, string tenantId, string clientId, string parentId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("sMenuId", menuId),
                    new SqlParameter("sParentId", parentId),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Menu>("SP_WHYMINH_API_GET_MENU_WITH_PARENT", parameters);
            return results;
        }

        public async Task<ActionResult<Base>> AddMenu(AddMenuRequest addParameterRequest)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", addParameterRequest.TenantId),
                    new SqlParameter("sClientId", addParameterRequest.ClientId),
                    new SqlParameter("sParentId", addParameterRequest.ParentId),
                    new SqlParameter("sMenuId", addParameterRequest.MenuId),
                    new SqlParameter("sName", addParameterRequest.Name),
                    new SqlParameter("sURL", addParameterRequest.Url),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_ADD_MENU", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdateMenu(UpdateMenuRequest updateParameterRequest)
        {
            SqlParameter[] parameters =
            {
                    new SqlParameter("sTenantId", updateParameterRequest.TenantId),
                    new SqlParameter("sClientId", updateParameterRequest.ClientId),
                    new SqlParameter("sParentId", updateParameterRequest.ParentId),
                    new SqlParameter("sMenuId", updateParameterRequest.MenuId),
                    new SqlParameter("sURL", updateParameterRequest.Url),
                    new SqlParameter("sName", updateParameterRequest.Name),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_UPDATE_MENU", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> DeleteMenu(string menuId, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", tenantId),
                    new SqlParameter("p_client_id", clientId),
                    new SqlParameter("p_menu_id", menuId)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_DELETE_MENU", parameters);
            return results.FirstOrDefault();
        }
    }
}
