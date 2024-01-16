using System.ComponentModel.DataAnnotations;

namespace RenovationTools.Models
{
    public class Tool
    {
        public int ToolId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
