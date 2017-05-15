using System;

namespace bank
{
    public class Account
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public Client Owner { get; set; }
        public double Rate { get; set; }
        public int Funds { get; set; }

        public static string selectType()
        {
            int value = Program.yesNo("What type of account would you like to open?", "Saving", "Cheking", true);
            string type = value == 1 ? "Saving" : "Checking";
            return type;
        }


        public void printInfo()
        {

        }

        public void history()
        {

        }

        
    }
}