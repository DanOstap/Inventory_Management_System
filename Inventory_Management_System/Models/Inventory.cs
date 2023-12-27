using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Inventory { get; set; }
        [Required]
        public string Name_Product { get; set; }
        [Required]
        public int Quantity_Products { get; set; }
        [Required]
        public string Storage { get; set; }
    }
}
