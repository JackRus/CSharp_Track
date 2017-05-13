using System;
using System.Linq;
using System.Collections.Generic;


namespace bank
{
    class Account
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public Client Owner { get; set; }
        public bool Status { get; set; }

        public int Rate { get; set; }
        public int Funds { get; set; }

        public void printInfo ()
        {
            Console.WriteLine($"Account: {Number}; Type: {Type}; Status: {Status}; Amount: {Funds}");
        }
        
    }

    class Client 
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Account> allAccounts { get; set; }
        public void CloseAccount(Account toClose) {

        }
        public void OpenAccount(Account toOpen) {

        }

    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the best Bank in the World!");
            Console.WriteLine("\n=======================================");
            Console.WriteLine(  "===*******===  BIG BANK  ===*******===");
            Console.WriteLine("\n=======================================");

            bool end = false;
            int choice;
            while (!end)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(please select one of the options):");
                Console.WriteLine("1. Open Account");
                Console.WriteLine("2. Close Account");
                Console.WriteLine("3. Check the balance of your accounts");
                Console.WriteLine("4. Make a deposit");
                Console.WriteLine("5. Withdrow money");
                Console.WriteLine("6. Quit");
                Console.WriteLine("\n");
                do
                {
                    Int32.TryParse(Console.ReadLine(), out choice);
                } while (choice < 1 && choice > 6);

                Console.WriteLine(choice);
            }
        }
    }
}
