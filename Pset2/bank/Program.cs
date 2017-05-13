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
        
    }

    class Checking: Account 
    {

    }

    class Saving: Account 
    {
        
    }

    class Client 
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Account> allAccounts { get; set; }
        public void CloseAccount(Account toClose) {


        }

    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the best Bank in the World!");
            Console.WriteLine("\n=======================================");
            Console.WriteLine(  "===*******===  NOTA BANK  ===*******===");
            Console.WriteLine("\n=======================================");

            bool end = false;
            while (!end)
            {
                Console.WriteLine("\n");
            }
        }
    }
}
