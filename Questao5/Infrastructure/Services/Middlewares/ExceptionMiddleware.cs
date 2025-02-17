using Questao5.Application.Responses;
using System.Net;
using System.Text.Json;

namespace Questao5.Infrastructure.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ApiResponse<string> response = new(ex.Message, "Internal server error");

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
