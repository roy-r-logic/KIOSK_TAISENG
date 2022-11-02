using System.ComponentModel.DataAnnotations;

namespace SSKWeb.Models.ViewModels
{
    public class CustomerInfoViewModel
    {
        [Required(ErrorMessage = "The Name field is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should only contain spacing and character")]
        [MaxLength(200, ErrorMessage = "Maximun character for name is 200")]
        public string customerName { get; set; }

        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid email format")]
        [Required(ErrorMessage = "The Email field is required")]
        [MaxLength(320, ErrorMessage = "Maximun character for email is 320")]
        public string customerEmail { get; set; }

        [RegularExpression(@"^((8|9)\d{7}|[0-7]\d*)$", ErrorMessage = "Invalid contact format,first number must be 8 or 9")]//start with 60 and no dash
        [MinLength(8, ErrorMessage = "Contact length should within 8 character")]
        [MaxLength(8, ErrorMessage = "Contact length should within 8 character")]
        [Required(ErrorMessage = "The Phone Number field is required")]
        
        public string customerPhoneNumber { get; set; }
    }
}
