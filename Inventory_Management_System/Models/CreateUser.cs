using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Management_System.Models
{
    public class CreateUser
    {

        [Required]
        [Key]
        public string User_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string User_Email { get; set; }
        [Required]
        [MinLength(20, ErrorMessage ="Length need be mode them 20 symboles")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }
        [Required]
        public string User_Phone { get; set;}
        [Required]
        public string User_Position{ get; set; }
    }
}
