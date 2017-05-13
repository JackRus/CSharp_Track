using System;
using System.Collections.Generic;
using System.Linq;

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

        public void printInfo()
        {
            Console.WriteLine($"Account: {Number}; Type: {Type}; Status: {Status}; Amount: {Funds}; Rate: {Rate}");
        }

    }

    class Client
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Account> allAccounts { get; set; }
        public void CloseAccount(Account toClose)
        {

        }
        public static void OpenAccount()
        {
            Account newAccount = new Account();

            // creating unique account number, based on time and date
            DateTime dt = DateTime.Now;
            newAccount.Number = dt.ToString("yyyyMMddHHmmss");
            Console.WriteLine($"Your New Account Number: {newAccount.Number}"); 
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        public static void menu()
        {
            int choice = 0;
            // infinite loop with a break point.
            while (true)
            {
                makeChoice(ref choice);

                if (choice == 1)
                {
                    Client.OpenAccount();
                    break;
                }
                else if (choice == 2)
                {
                    // TODO
                }
                else if (choice == 3)
                {
                    // TODO
                }
                else if (choice == 4)
                {
                    // TODO
                }
                else if (choice == 5)
                {
                    // TODO
                }
                else
                {
                    thankYou();
                    break;
                }
            }
        }

        public static void makeChoice(ref int choice)
        {
            do 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to the best Bank in the World!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n=======================================");
                Console.WriteLine("===*******===  BIG BANK  ===*******===");
                Console.WriteLine("=======================================\n");
                Console.ResetColor();
                Console.WriteLine("What would you like to do?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    1. Open New Account");
                Console.WriteLine("    2. Close Account");
                Console.WriteLine("    3. Check the balance of your accounts");
                Console.WriteLine("    4. Make a deposit");
                Console.WriteLine("    5. Withdrow money");
                Console.WriteLine("    6. Quit");
                Console.ResetColor();
                Console.Write("Plese select a number (1-6): ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.Clear();
            } while (choice < 1 || choice > 6);
        }

        public static void thankYou()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n======================================");
            Console.WriteLine($"* Thank you for being with BIG BANK! *");
            Console.WriteLine("======================================\n");
            Console.ResetColor();
        }
    }
}