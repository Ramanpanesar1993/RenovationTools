using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RenovationTools.Models.Repositories;

namespace RenovationTools.Filters.ExceptionFilters
{
    public class Tools_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            // Customize the following code based on your requirements
            var toolId = context.RouteData.Values["id"] as string;
            if (int.TryParse(toolId, out int toolIdParsed))
            {
                if (!ToolsRepository.ToolExists(toolIdParsed))
                {
                    context.ModelState.AddModelError("Tool", "Tool does not exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}