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

        public double Rate { get; set; }
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

        public static void OpenAccount(Client myCustomer, string type)
        {
            Account newAccount = new Account();

            // creating unique account number, based on time and date
            DateTime dt = DateTime.Now;
            newAccount.Number = dt.ToString("yyyyMMddHHmmss");
            newAccount.Type = type;
            newAccount.Rate = type == "Saving" ? 1.5 : 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Your New Account #: {newAccount.Number}");
            Console.WriteLine($"----------------------------------\n");
            Console.ResetColor();
            myCustomer.allAccounts.Add(newAccount);

        }

        public static void Greet()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("***************************************");
            Console.WriteLine(" Welcome to the best Bank in the World");
            Console.WriteLine("                BIG BANK              ");
            Console.WriteLine("***************************************\n");
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client customer = new Client();
            customer.allAccounts = new List<Account>();
            Account account = new Account();

            Client.Greet();
            if (yesNo("Hi! Do you have an account in BIG BANK?", "Yes", "No", false) == 1)
            {
                askName(customer);
            }
            else
            {

            }


            // if (  )
            // {
            //     thankYou();
            //     return;
            // }
            // else
            // {
            //     Client.OpenAccount();
            //     if (yesNo("Would you like to continue?") == 2) return;
            // }
            menu(account, customer);
        }

        public static int yesNo(string message, string yes, string no, bool needHeader)
        {
            int choice;
            do {
                if (needHeader) header();
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"    [1] {yes}");
                Console.WriteLine($"    [2] {no}");
                Console.ResetColor();
                Console.Write("\nPlese select 1 or 2: ");
                int.TryParse(Console.ReadLine(), out choice);

                if (choice != 1 || choice != 2)
                    Client.Greet();

            } while (choice < 1 || choice > 2);
            return choice;
        }

        public static void askName(Client myCustomer)
        {
            header();
            Console.WriteLine("To access your account please provide your full name.");
            Console.Write("\nWhat is your FIRST name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            myCustomer.name = Console.ReadLine().Trim();
            Console.ResetColor();
            
            Console.Write("              LAST name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            myCustomer.lastName = Console.ReadLine().Trim();
            Console.ResetColor(); 
        }
        public static void newClient()
        {

        }
        

        public static void menu(Account myAccount, Client myCustomer)
        {
            int choice = 0;
            // infinite loop with a break point.
            while (true)
            {
                // displays the menu
                makeChoice(ref choice, myCustomer.name);

                if (choice == 1)
                {
                    string type = selectType();
    
                    header();
                    Client.OpenAccount(myCustomer, type);
                    if (yesNo($"Would you like yo continue, {myCustomer.name}?","Yes", "No, quit", false) == 2) 
                    {
                        thankYou();
                        break;
                    }
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

        public static void makeChoice(ref int choice, string name)
        {
            do {
                header();
                Console.WriteLine($"What would you like to do, {name}?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    1. Open New Account");
                Console.WriteLine("    2. Close Account");
                Console.WriteLine("    3. See all of your accounts");
                Console.WriteLine("    4. Make a deposit");
                Console.WriteLine("    5. Withdrow money");
                Console.WriteLine("    6. Quit");
                Console.ResetColor();
                Console.Write("\nPlese select a number (1-6): ");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n====================================");
            Console.WriteLine($"* Thank you for visiting BIG BANK! *");
            Console.WriteLine("====================================\n\n\n");
            Console.ResetColor();
        }

        public static void header()
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToString("HH:mm");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================================");
            Console.WriteLine("=               BIG BANK              =");
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Date: {date}            Time: {time}\n");
            Console.ResetColor();
        }

        public static string selectType()
        {
            int value = yesNo("What type of account would you like to open?", "Saving", "Cheking", true);
            string type = value == 1 ? "Saving" : "Checking";
            return type;
        }
    }
}