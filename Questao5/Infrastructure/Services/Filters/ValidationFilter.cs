using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Questao5.Application.Responses;

namespace Questao5.Infrastructure.Services.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(new ApiResponse<string>(errors, "Bad request"));
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context) { }
    }
}
