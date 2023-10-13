using API.Entities;
using API.Models.Menu;
using API.Models.NotificationMethod;
using Microsoft.AspNetCore.Mvc;

namespace API.Interface
{
    public interface INotificationMethodRepository
    {
        public Task<ActionResult<List<NotificationMethod>>> GetNotificationMethod(string notificationMethodId, string tenantId, string clientId);

        public Task<ActionResult<Base>> AddNotificationMethod(AddNotificationMethodRequest addNotificationMethodRequestt);

        public Task<ActionResult<Base>> UpdateNotificationMethod(UpdateNotificationMethodRequest updateNotificationMethodRequest);

        public Task<ActionResult<Base>> DeleteNotificationMethod(string menuId, string tenantId, string clientId);
    }
}
