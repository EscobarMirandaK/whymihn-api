using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.Menu;
using API.Models.NotificationMethod;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("notificationMethod")]
    [ApiController]
    public class NotificationMethodController: ControllerBase
    {
        public INotificationMethodRepository notificationMethodRepository;

        public NotificationMethodController(INotificationMethodRepository notificationMethodRepository)
        {
            this.notificationMethodRepository = notificationMethodRepository;
        }

        [Authorize(Role.ADMIN)]
        [Route("GetNotificationMethod/{notificationMethodId}/{tenantId}/{clientId}")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationMethod>>> GetNotificationMethod(string notificationMethodId, string tenantId, string clientId)
        {
            return await this.notificationMethodRepository.GetNotificationMethod(notificationMethodId, tenantId, clientId);
        }

        [Authorize(Role.ADMIN)]
        [Route("AddNotificationMethod")]
        [HttpPost]
        public async Task<ActionResult<NotificationMethod>> AddNotificationMethod(AddNotificationMethodRequest addNotificationMethodRequest)
        {
            var result = await this.notificationMethodRepository.AddNotificationMethod(addNotificationMethodRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("UpdateNotificationMethod")]
        [HttpPut]
        public async Task<ActionResult<NotificationMethod>> UpdateNotificationMethod(UpdateNotificationMethodRequest updateNotificationMethodRequest)
        {
            var result = await this.notificationMethodRepository.UpdateNotificationMethod(updateNotificationMethodRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("DeleteNotificationMethod/{menuId}/{tenantId}/{clientId}")]
        [HttpDelete]
        public async Task<ActionResult<NotificationMethod>> DeleteNotificationMethod(string menuId, string tenantId, string clientId)
        {
            var result = await this.notificationMethodRepository.DeleteNotificationMethod(menuId, tenantId, clientId);

            return Ok(result);
        }
    }
}
