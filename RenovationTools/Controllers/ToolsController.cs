using Microsoft.AspNetCore.Mvc;
using RenovationTools.Filters;
using RenovationTools.Filters.ActionFilters;
using RenovationTools.Filters.ExceptionFilters;
using RenovationTools.Models;
using RenovationTools.Models.Repositories;

namespace RenovationTools.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTools()
        {
            return Ok(ToolsRepository.GetTools());
        }

        [HttpGet("{ToolId}")]
        [Tools_ValidateToolIdFilter]
        public IActionResult GetToolById(int ToolId)
        {
            return Ok(ToolsRepository.GetToolById(ToolId));
        }

        [HttpPost]
        [Tools_ValidateCreateToolFilter]
        public IActionResult CreateTool([FromForm] Tool tool)
        {
            ToolsRepository.AddTool(tool);
            return CreatedAtAction(nameof(GetToolById),
                new { ToolId = tool.ToolId },
                tool);
        }

        [HttpPut("{ToolId}")]
        [Tools_ValidateToolIdFilter]
        [Tools_ValidateUpdateToolFilter]
        [Tools_HandleUpdateExceptionsFilter]
        public IActionResult UpdateTool(int ToolId, Tool tool)
        {
            ToolsRepository.UpdateTool(tool);
            return NoContent();
        }

        [HttpDelete("{ToolId}")]
        [Tools_ValidateToolIdFilter]
        public IActionResult DeleteTool(int ToolId)
        {
            var tool = ToolsRepository.GetToolById(ToolId);
            ToolsRepository.DeleteTool(ToolId);
            return Ok(tool);
        }
    }
}
