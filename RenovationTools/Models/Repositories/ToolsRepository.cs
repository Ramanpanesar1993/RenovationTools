using System;
using System.Collections.Generic;
using System.Linq;

namespace RenovationTools.Models.Repositories
{
    public class ToolsRepository
    {
        private static List<Tool> tools = new List<Tool>
        {
            new Tool { ToolId = 1, Name = "Hammer", Type = "Hand Tool", Price = 19.99 },
            new Tool { ToolId = 2, Name = "Drill", Type = "Power Tool", Price = 89.99 },
            new Tool { ToolId = 3, Name = "Screwdriver", Type = "Hand Tool", Price = 9.99 },
            new Tool { ToolId = 4, Name = "Circular Saw", Type = "Power Tool", Price = 129.99 },
            new Tool { ToolId = 5, Name = "Saw", Type = "Hand Tool", Price = 29.99 },
        };

        public static List<Tool> GetTools()
        {
            return tools;
        }

        public static bool ToolExists(int toolId)
        {
            return tools.Any(x => x.ToolId == toolId);
        }

        public static Tool GetToolById(int toolId)
        {
            return tools.FirstOrDefault(x => x.ToolId == toolId);
        }

        public static string AddTool(Tool tool)
        {
            if (ToolExists(tool.ToolId))
            {
                return $"Tool with ID {tool.ToolId} already exists!";
            }

            tools.Add(tool);

            return $"Tool '{tool.Name}' added successfully!";
        }

        public static string UpdateTool(Tool updatedTool)
        {
            var existingTool = tools.FirstOrDefault(tool => tool.ToolId == updatedTool.ToolId);
            if (existingTool != null)
            {
                existingTool.Name = updatedTool.Name;
                existingTool.Type = updatedTool.Type;
                existingTool.Price = updatedTool.Price;

                return $"Tool '{existingTool.Name}' updated successfully!";
            }
            else
            {
                throw new InvalidOperationException($"Tool with ID {updatedTool.ToolId} not found");
            }
        }

        public static string DeleteTool(int toolId)
        {
            var toolToRemove = tools.FirstOrDefault(tool => tool.ToolId == toolId);
            if (toolToRemove != null)
            {
                tools.Remove(toolToRemove);

                return $"Tool '{toolToRemove.Name}' deleted successfully!";
            }
            else
            {
                throw new InvalidOperationException($"Tool with ID {toolId} not found");
            }
        }

        public static Tool GetToolByProperties(string name, string type, double price)
        {
            return tools.FirstOrDefault(tool =>
                tool.Name == name &&
                tool.Type == type &&
                tool.Price == price);
        }
    }
}
