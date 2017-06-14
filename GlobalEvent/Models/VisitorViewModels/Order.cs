namespace GlobalEvent.Models.VisitorViewModels
{
    public class Order
    {
        public int ID { get; set; }
        public int Number { get; set; } 
        public int Amount { get; set; }
        public int CheckedIn { get; set; }
        public bool Full { get; set; }

        public Order()
        {
            Number = 0;
            Amount = 0;
            CheckedIn = 0;
            Full = false;
        }
    }
}