using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Client customer = new Client();
            customer.allAccounts = new List<Account>();
            Account account = new Account();

            Client.Greet();
            if (yesNo("Hi! Are you a BIG BANK's customer?", "Yes", "No", false) == 1)
            {
                Program.header();
                Console.WriteLine("To access your account please provide your full name.");
                customer.askName();
            }
            else if (yesNo("Would you like to become BIG BANK's customer?", "Yes", "No", false) == 1)
            {
                Program.header();
                Console.WriteLine("Wonderful!!! We just need your full name to register you in our system!");
                customer.askName();
            }
            else
            {
                return;
            }
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

            } while (choice < 1 || choice > 2);
            return choice;
        }

        public static void menu(Account myAccount, Client myCustomer)
        {
            int choice = 0;
            // infinite loop with a break point.
            while (true)
            {
                // displays the menu
                Client.makeChoice(ref choice, myCustomer.name);

                if (choice == 1)
                {
                    string type = Account.selectType();
                    header();
                    Client.OpenAccount(myCustomer, type);
                    continueOrExit(myCustomer.name);
                }
                else if (choice == 2)
                {
                    int indexToClose = myCustomer.selectClose();
                    if (indexToClose != 0)
                    {
                        header();
                        myCustomer.CloseAccount(indexToClose);
                        continueOrExit(myCustomer.name);
                    }
                }
                else if (choice == 3)
                {
                    header();
                    if (myCustomer.listOpen() !=0)
                        continueOrExit(myCustomer.name);
                }
                else if (choice == 4)
                {
                    int deposit = 0;
                    int indexToDeposit = myCustomer.selectAndDeposit(out deposit);
                    if (indexToDeposit != 0)
                    {
                        header();
                        myCustomer.Deposit(indexToDeposit, deposit);
                        continueOrExit(myCustomer.name);
                    }
                }
                else if (choice == 5)
                {
                    int withdraw = 0;
                    int indexToDeposit = myCustomer.selectAndWithdraw(out withdraw);
                    if (indexToDeposit != 0)
                    {
                        withdraw = -withdraw;
                        header();
                        myCustomer.Deposit(indexToDeposit, withdraw);
                        continueOrExit(myCustomer.name);
                    }
                }
                else
                {
                    Client.thankYou();
                    break;
                }
            }
        }

        public static void header()
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd, dddd");
            string time = dt.ToString("HH:mm");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================================");
            Console.WriteLine("=               BIG BANK              =");
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{date}          Time: {time}\n");
            Console.ResetColor();
        }

        public static void continueOrExit(string name)
        {
            if (yesNo($"Would you like to continue, {name}?", "Yes", "No, quit", false) == 2)
            {
                Client.thankYou();
                System.Environment.Exit(0);
            }
        }
    }
}