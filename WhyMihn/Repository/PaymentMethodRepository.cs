using API.Entities;
using API.Interface;
using API.Models.NotificationMethod;
using API.Models.PaymentMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IDatabaseHelper databaseHelper;

        public PaymentMethodRepository(IDatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }
        public async Task<ActionResult<List<PaymentMethod>>> GetPaymentMethod(string paymentMethodId, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId), // 1 as default page to reuse the stored procedure
                    new SqlParameter("sPaymentMethodId", paymentMethodId),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<PaymentMethod>("SP_WHYMINH_API_GET_PAYMENT_METHOD", parameters);
            return results;
        }

        public async Task<ActionResult<Base>> AddPaymentMethod(AddPaymentMethodRequest addPaymentMethodRequest)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", addPaymentMethodRequest.TenantId),
                    new SqlParameter("sClientId", addPaymentMethodRequest.ClientId),
                    new SqlParameter("sPaymentMethodId", addPaymentMethodRequest.PaymentMethodId),
                    new SqlParameter("sName", addPaymentMethodRequest.Name),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_ADD_PAYMENT_METHOD", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> UpdatePaymentMethod(UpdatePaymentMethodRequest updatePaymentMethodRequest)
        {
            SqlParameter[] parameters =
            {
                    new SqlParameter("sTenantId", updatePaymentMethodRequest.TenantId),
                    new SqlParameter("sClientId", updatePaymentMethodRequest.ClientId),
                    new SqlParameter("sPaymentMethodId", updatePaymentMethodRequest.PaymentMethodId),
                    new SqlParameter("sName", updatePaymentMethodRequest.Name),
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_UPDATE_PAYMENT_METHOD", parameters);
            return results.FirstOrDefault();
        }

        public async Task<ActionResult<Base>> DeletePaymentMethod(string paymentMethodId, string tenantId, string clientId)
        {
            SqlParameter[] parameters =
                {
                    new SqlParameter("sTenantId", tenantId),
                    new SqlParameter("sClientId", clientId),
                    new SqlParameter("sPaymentMethodId", paymentMethodId)
                };
            var results = await this.databaseHelper.ExecuteStoredProcedure<Base>("SP_WHYMINH_API_DELETE_PAYMENT_METHOD", parameters);
            return results.FirstOrDefault();
        }
    }
}
