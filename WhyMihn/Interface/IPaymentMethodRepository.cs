using API.Entities;
using API.Models.NotificationMethod;
using API.Models.PaymentMethod;
using Microsoft.AspNetCore.Mvc;

namespace API.Interface
{
    public interface IPaymentMethodRepository
    {
        public Task<ActionResult<List<PaymentMethod>>> GetPaymentMethod(string paymentMethodId, string tenantId, string clientId);

        public Task<ActionResult<Base>> AddPaymentMethod(AddPaymentMethodRequest addPaymentMethodRequest);

        public Task<ActionResult<Base>> UpdatePaymentMethod(UpdatePaymentMethodRequest updatePaymentMethodRequest);

        public Task<ActionResult<Base>> DeletePaymentMethod(string paymentMethodId, string tenantId, string clientId);
    }
}
