
using System.Net;
using System.Text.Json;

namespace ManheimWebApi.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger) => _logger = logger;
       

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An unhandled exception occured");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new
                {
                    message = "An unexpected error occured ! Please try again later",
                    error = e.Message,
                    stackTrace = e.StackTrace
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}
