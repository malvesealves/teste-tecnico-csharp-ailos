using System.Net;

namespace Questao5.Domain.Language
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //catch (DomainException ex)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    await context.Response.WriteAsync(ex.Message);
            //}
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Ocorreu um erro inesperado. Tente novamente mais tarde.");
            }
        }
    }
}
