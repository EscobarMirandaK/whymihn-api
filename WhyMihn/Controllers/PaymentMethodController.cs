using API.Entities;
using API.Extensions;
using API.Interface;
using API.Models.NotificationMethod;
using API.Models.PaymentMethod;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("paymentMethod")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        public IPaymentMethodRepository paymentMethodRepository;

        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            this.paymentMethodRepository = paymentMethodRepository;
        }

        [Authorize(Role.ADMIN)]
        [Route("GetPaymentMethod/{paymentMethodId}/{tenantId}/{clientId}")]
        [HttpGet]
        public async Task<ActionResult<List<PaymentMethod>>> GetNotificationMethod(string paymentMethodId, string tenantId, string clientId)
        {
            return await this.paymentMethodRepository.GetPaymentMethod(paymentMethodId, tenantId, clientId);
        }

        [Authorize(Role.ADMIN)]
        [Route("AddNotificationMethod")]
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> AddPaymentMethod(AddPaymentMethodRequest addPaymentMethodRequest)
        {
            var result = await this.paymentMethodRepository.AddPaymentMethod(addPaymentMethodRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("UpdateNotificationMethod")]
        [HttpPut]
        public async Task<ActionResult<PaymentMethod>> UpdateNotificationMethod(UpdatePaymentMethodRequest updatePaymentMethodRequest)
        {
            var result = await this.paymentMethodRepository.UpdatePaymentMethod(updatePaymentMethodRequest);
            return Ok(result);
        }

        [Authorize(Role.ADMIN)]
        [Route("DeleteNotificationMethod/{menuId}/{tenantId}/{clientId}")]
        [HttpDelete]
        public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod(string paymentMethodId, string tenantId, string clientId)
        {
            var result = await this.paymentMethodRepository.DeletePaymentMethod(paymentMethodId, tenantId, clientId);

            return Ok(result);
        }
    }
}
