namespace CheckIn.Models.VisitorViewModels
{
    public class Visitor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }
        public string Company { get; set; }
        public bool GroupOwner { get; set; }
        public bool CheckIned { get; set; }
        public bool Registered { get; set; }

    }
}