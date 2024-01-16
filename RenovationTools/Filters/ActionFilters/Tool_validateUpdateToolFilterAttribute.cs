using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using RenovationTools.Models;

namespace RenovationTools.Filters.ActionFilters
{
    public class Tools_ValidateUpdateToolFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var toolId = context.ActionArguments["toolId"] as int?;
            var tool = context.ActionArguments["tool"] as Tool;

            if (toolId.HasValue && tool != null && toolId != tool.ToolId)
            {
                context.ModelState.AddModelError("ToolId", "ToolId is not the same as my id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
