using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Models.ViewModels
{
    public class PostDropGoRegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should only contain spacing and character")]//only character and spacing
        [MaxLength(200, ErrorMessage = "Maximun character for name is 200")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^(01)[02-46-9]*[0-9]{7}$|^(01)[1]*[0-9]{8}$", ErrorMessage = "Invalid contact format")]//start with 60 and no dash
        [MinLength(10, ErrorMessage = "Contact length should within range 11 or 12 character")]
        [MaxLength(11, ErrorMessage = "Contact length should within range 11 or 12 character")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Invalid email format")]//Email Format Only
        [MaxLength(320, ErrorMessage = "Maximun character for email is 320")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Model type is required")]
        public string ModelType { get; set; }

        [Required(ErrorMessage = "Serial number is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Serial number should only contain character and number")]//Character and Number Only
        [MaxLength(10, ErrorMessage = "Maximun character for serial number is 10")]
        public string SerialNumber { get; set;}

        [Required(ErrorMessage = "Defect type is required"), MinLength(1, ErrorMessage = "Defect type is required")]
        public int[] DefectTypeID { get; set; }

        [Required(ErrorMessage = "Accessories type is required"), MinLength(1, ErrorMessage = "Accessories type is required")]
        public int[] AccessoriesTypeID { get; set; }

        [Required(ErrorMessage = "Set Condition is required"), MinLength(1, ErrorMessage = "Set Condition is required")]
        public int[] SetConditionTypeID { get; set; }

        [Required(ErrorMessage = "Warranty type is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Warranty type is required")]
        public int WarrantyTypeID { get; set; }

        [Required]
        public bool IsTermConditionChecked { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "This is required")]
        public int SystemLocationID { get; set; }

        public bool IsCheckedTnC { get; set; }


        public string AccessoriesOthers { get; set; }
        public string DefectsOthers { get; set; }
        public int? OutWarrantyTypeID { get; set; }
        public string SetConditionOther { get; set; }

    }
}
