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
        public async Task<ActionResult<Menu>> GetMenu(string menuId, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", tenantId),
                    new SqlParameter("p_client_id", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("p_menu_id", menuId),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedureWithPagination<Menu>("SP_WHYMINH_Get_Menu", parameters);
            return results.Results.FirstOrDefault();
        }

        public async Task<ActionResult<Menu>> GetMenuWithParent(string menuId, string tenantId, string clientId, string parentId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", tenantId),
                    new SqlParameter("p_client_id", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("p_menu_id", menuId),
                    new SqlParameter("p_parent_id", parentId),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedureWithPagination<Menu>("SP_WHYMINH_Get_Menu_With_Parent", parameters);
            return results.Results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> AddMenu(AddMenuRequest addParameterRequest)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("p_tenant_id", addParameterRequest.TenantId),
                    new SqlParameter("p_client_id", addParameterRequest.ClientId),
                    new SqlParameter("p_parent_id", addParameterRequest.ParentId),
                    new SqlParameter("p_menu_id", addParameterRequest.MenuId),
                    new SqlParameter("p_name", addParameterRequest.Name),
                    new SqlParameter("p_url", addParameterRequest.Url),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_Add_Menu", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdateMenu(UpdateMenuRequest updateParameterRequest)
        {
            SqlParameter[] parameters =
            {
                    new SqlParameter("p_tenant_id", updateParameterRequest.TenantId),
                    new SqlParameter("p_client_id", updateParameterRequest.ClientId),
                    new SqlParameter("p_parent_id", updateParameterRequest.ParentId),
                    new SqlParameter("p_menu_id", updateParameterRequest.MenuId),
                    new SqlParameter("p_url", updateParameterRequest.Url),
                    new SqlParameter("p_name", updateParameterRequest.Name),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_Update_Menu", parameters);
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
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_Delete_Menu", parameters);
            return results.FirstOrDefault();
        }
    }
}
