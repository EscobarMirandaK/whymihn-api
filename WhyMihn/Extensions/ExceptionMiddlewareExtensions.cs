using API.Models.Base;
using System.Net;
using System.Text.Json;

namespace API.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> log;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> log)
        {
            _next = next;
            this.log = log;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var baseResponse = new BaseResponse(true);
            var stackTraceId = Guid.NewGuid();
            baseResponse.AddError(exception.Message, stackTraceId);
            log.LogError($"Message: {exception.Message} - StackTraceId: {stackTraceId} - StackTrace: {exception.StackTrace}");
            await context.Response.WriteAsync(JsonSerializer.Serialize(baseResponse));
        }
    }
}