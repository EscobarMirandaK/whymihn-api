using API.Entities;
using API.Interface;
using API.Models.Menu;
using API.Models.NotificationMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class NotificationMethodRepository: INotificationMethodRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public NotificationMethodRepository(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }
        public async Task<ActionResult<List<NotificationMethod>>> GetNotificationMethod(string notificationMethodId, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("sNotificationMethodId", notificationMethodId),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<NotificationMethod>("SP_WHYMINH_API_GET_NOTIFICATION_METHOD", parameters);
            return results;
        }

        public async Task<ActionResult<Base>> AddNotificationMethod(AddNotificationMethodRequest addNotificationMethodRequest)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", addNotificationMethodRequest.TenantId),
                    new SqlParameter("sClientId", addNotificationMethodRequest.ClientId),
                    new SqlParameter("sNotificationMethodId", addNotificationMethodRequest.NotificationMethodId),
                    new SqlParameter("sName", addNotificationMethodRequest.Name),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_ADD_NOTIFICATION_METHOD", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdateNotificationMethod(UpdateNotificationMethodRequest updateNotificationMethodRequest)
        {
            SqlParameter[] parameters =
            {
                    new SqlParameter("sTenantId", updateNotificationMethodRequest.TenantId),
                    new SqlParameter("sClientId", updateNotificationMethodRequest.ClientId),
                    new SqlParameter("sNotificationMethodId", updateNotificationMethodRequest.NotificationMethodId),
                    new SqlParameter("sName", updateNotificationMethodRequest.Name),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_UPDATE_NOTIFICATION_METHOD", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> DeleteNotificationMethod(string notificationMethod, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId),
                    new SqlParameter("sNotificationMethodId", notificationMethod)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_DELETE_NOTIFICATION_METHOD", parameters);
            return results.FirstOrDefault();
        }
    }
}
