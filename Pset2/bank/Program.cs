using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;

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
            toClose.Status = false;
        }

        public static void OpenAccount()
        {
            Account newAccount = new Account();

            // creating unique account number, based on time and date
            DateTime dt = DateTime.Now;
            newAccount.Number = dt.ToString("yyyyMMddHHmmss");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n=========================================");
            Console.WriteLine($" Your New Account Number: {newAccount.Number} ");
            Console.WriteLine("=========================================");
            Console.ResetColor();
        }

        public static void Greet()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("****************************************");
            Console.WriteLine(" Welcome to the best Bank in the World!");
            Console.WriteLine("                 BIG BANK              ");
            Console.WriteLine("****************************************\n");
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client.Greet();
            if (yesNo("Hi! Do you an acount in BIG BANK?") == 1)
            {
                askName();
            }
            else
            {

            }


            if (intro == 2)
            {
                seeYou();
                return;
            }
            else
            {
                Client.OpenAccount();
                if (next() == 2) return;
            }
            menu();
        }

        public static int yesNo(string message)
        {
            int choice;
            do {
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    [1] Yes");
                Console.WriteLine("    [2] No");
                Console.ResetColor();
                Console.Write("Plese select 1 or 2: ");
                int.TryParse(Console.ReadLine(), out choice);

                if (choice != 1 || choice != 2)
                    Client.Greet();

            } while (choice < 1 || choice > 2);
            return choice;

        }

        public static void askName()
        {
            
        }
        public static void newClient()
        {

        }
        

        public static void menu()
        {
            int choice = 0;
            // infinite loop with a break point.
            while (true)
            {
                // displays the menu
                makeChoice(ref choice);

                if (choice == 1)
                {
                    Client.OpenAccount();
                    if (next() == 2) break;
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
            do {
                Console.Clear();
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

        /*****************
        Good Bye to Client
        *****************/
        public static void thankYou()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n======================================");
            Console.WriteLine($"* Thank you for being with BIG BANK! *");
            Console.WriteLine("======================================\n");
            Console.ResetColor();
        }

        public static void seeYou()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n====================================");
            Console.WriteLine($"* Thank you for visiting BIG BANK! *");
            Console.WriteLine("====================================\n");
            Console.ResetColor();
        }

        /******************************************
        Asks client if he wants to continue or quit
        ******************************************/
        public static int next()
        {
            int choice;
            do {
                Console.WriteLine("\nWhat would you like to do next:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    [1] Continue");
                Console.WriteLine("    [2] Quit");
                Console.ResetColor();
                Console.Write("Plese select 1 or 2: ");
                int.TryParse(Console.ReadLine(), out choice);
                if (choice != 1 || choice != 2)
                    Console.Clear();
            } while (choice < 1 || choice > 2);
            return choice;
        }

        

    }
}