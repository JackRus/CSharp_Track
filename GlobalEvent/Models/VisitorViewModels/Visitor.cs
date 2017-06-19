using System.ComponentModel.DataAnnotations;

namespace GlobalEvent.Models.VisitorViewModels
{
    public class Visitor
    {
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Contains non Alphabetic characters.")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Contains non Alphabetic characters.")]
        public string Last { get; set; }
        
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        public string RegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Work Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Work/Cell Phone")]
        public string Phone { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Ext. (optional)")]
        public string Extention { get; set; }

        [Required]
        public string Occupation { get; set; }
 
        [Required]
        public string Company { get; set; }
        public bool GroupOwner { get; set; }
        public bool CheckIned { get; set; }
        public bool Registered { get; set; }
    }
}