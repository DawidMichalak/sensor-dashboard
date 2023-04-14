using sensor.Domain.Exceptions;
using System.Text.Json;

namespace sensor.Api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.StatusCode = GetStatusCode(e);
                response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { errors = e?.Message });
                await response.WriteAsync(result);
            }
        }

        private int GetStatusCode(Exception e)
        {
            return e switch
            {
                InvalidDateRangeException => 400,
                _ => 500,
            };
        }
    }
}
