using System.ComponentModel.DataAnnotations;

namespace GlobalEvent.Models.VisitorViewModels
{
    public class Visitor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        public string RegistrationNumber { get; set; }

        [Display(Name = "Work Email")]
        public string Email { get; set; }

        [Display(Name = "Work Phone")]
        public string Phone { get; set; }

        [Display(Name = "Ext.")]
        public string Extention { get; set; }
        public string Occupation { get; set; }
        public string Company { get; set; }
        public bool GroupOwner { get; set; }
        public bool CheckIned { get; set; }
        public bool Registered { get; set; }
    }
}