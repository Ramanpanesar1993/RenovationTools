using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using RenovationTools.Models;
using RenovationTools.Models.Repositories;

namespace RenovationTools.Filters.ActionFilters
{
    public class Tools_ValidateCreateToolFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var tool = context.ActionArguments["tool"] as Tool;
            if (tool == null)
            {
                context.ModelState.AddModelError("Tool", "Tool object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                // Customize this part based on your validation logic for creating a tool
                var existingTool = ToolsRepository.GetToolByProperties(tool.Name, tool.Type, tool.Price);
                if (existingTool != null)
                {
                    context.ModelState.AddModelError("Tool", "Tool with similar properties already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
