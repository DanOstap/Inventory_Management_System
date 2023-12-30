using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Management_System.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Product { get; }
        [Required]
        public string Name_Product { get; set; }
        [Required]
        public string Description_Product { get; set; }
        [Required]
        public string Manufacture_Product { get; set; }
        [Required]
        public double Price_Product { get; set; }
    }
}
