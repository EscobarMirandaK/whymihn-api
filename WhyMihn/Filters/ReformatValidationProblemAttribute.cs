using API.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class ReformatValidationProblemAttribute : ActionFilterAttribute
    {
        readonly ILogger<ReformatValidationProblemAttribute> log;

        public ReformatValidationProblemAttribute(ILogger<ReformatValidationProblemAttribute> log)
        {
            this.log = log;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var baseResponse = new BaseResponse(true);
                var errors = context.ModelState?.Values.SelectMany(v => v.Errors);

                foreach (var error in errors)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    var stackTraceId = Guid.NewGuid();
                    log.LogError($"Message: {error.ErrorMessage} - StackTraceId: {stackTraceId} - StackTrace: {error.Exception?.StackTrace}");
                    baseResponse.AddError(error.ErrorMessage, stackTraceId);
                }
                
                context.Result = new ObjectResult(baseResponse);
            }
            
            base.OnResultExecuting(context);
        }
    }
}
