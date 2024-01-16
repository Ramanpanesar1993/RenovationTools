using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RenovationTools.Models.Repositories;

namespace RenovationTools.Filters.ActionFilters
{
    public class Tools_ValidateToolIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var toolId = context.ActionArguments["toolId"] as int?;
            if (toolId.HasValue)
            {
                if (toolId.Value <= 0)
                {
                    context.ModelState.AddModelError("ToolId", "ToolId is invalid.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else if (!ToolsRepository.ToolExists(toolId.Value))
                {
                    context.ModelState.AddModelError("ToolId", "ToolId does not exist.");
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
    }
}
