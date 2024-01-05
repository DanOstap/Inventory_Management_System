using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class PathProduct
    {
        [Required]
        public string Manufacture_Product { get; set; }
        [Required]
        public double Price_Product { get; set; }
    }
}
