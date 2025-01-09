using RossBoiler.Application.WebAPI.Utils;
using RossBoiler.Common;

namespace RossBoiler.Application.WebAPI.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICorrelationIdProvider correlationIdProvider)
        {
            var correlationId = context.Request.Headers["X-Correlation-ID"].FirstOrDefault()
                                ?? Guid.NewGuid().ToString();

            correlationIdProvider.SetCorrelationId(correlationId);

            // Add the Correlation ID to the response headers for client-side use
            context.Response.Headers["X-Correlation-ID"] = correlationId;

            await _next(context);
        }
    }

    

}
