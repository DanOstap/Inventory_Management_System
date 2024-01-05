using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class PathInventory
    {
        [Required]
        public int Quantity_Products { get; set; }
        [Required]
        public string Storage { get; set; }
    }
}
