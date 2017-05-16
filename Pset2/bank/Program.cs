using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


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
            else 
            {
                if (yesNo("Would you like to become a BIG BANK's customer?", "Yes", "No", true) == 1)
                {
                    Program.header();
                    Console.WriteLine("Wonderful!!! We just need your full name to register you in our system!");
                    customer.askName();
                }
                else
                {
                    Client.thankYou();
                    return;
                }
            }
            menu(account, customer);
        }

        public static int yesNo(string message, string yes, string no, bool needHeader)
        {
            int choice;
            int count = 0;
            do {
                count++;
                if (count > 1) 
                    needHeader = true;
                if (needHeader) header();
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[1] {yes}");
                Console.WriteLine($"[2] {no}");
                Console.ResetColor();
                Console.Write("Plese select 1 or 2: ");
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
                int all = myCustomer.allAccounts.Count;
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
                    if (all == 0)
                        myCustomer.noAccounts();    
                    else
                    {
                        int index = myCustomer.select("close");
                        myCustomer.CloseAccount(index);
                    }
                }
                else if (choice == 3)   // LIST ALL ACCOUNTS
                {
                    header();
                    if (all == 0)
                        myCustomer.noAccounts();    
                    else
                    {
                        myCustomer.listOpen();
                        continueOrExit(myCustomer.name);
                    }
                }
                else if (choice == 4)
                {
                    if (all == 0)
                        myCustomer.noAccounts();    
                    else
                    {   
                        int deposit = 0;
                        int indexToDeposit = myCustomer.selectAndDeposit(out deposit);
                        myCustomer.Deposit(indexToDeposit, deposit);
                    }
                }
                else if (choice == 5)
                {
                    if (all == 0)
                        myCustomer.noAccounts();    
                    else
                    {    
                        int withdraw = 0;
                        int indexToDeposit = myCustomer.selectAndWithdraw(out withdraw);
                        withdraw = -withdraw;
                        myCustomer.Deposit(indexToDeposit, withdraw);
                    }
                }
                else
                {
                    saveToFile(myCustomer);
                    Client.thankYou();
                    break;
                }
            }
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
            Console.WriteLine($"{date}                  Time: {time}\n");
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

        public static void saveToFile(Client toSave)
        {
            string json = JsonConvert.SerializeObject(toSave);
            string fileName = "clients/" + toSave.name + toSave.lastName + ".txt";
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText(fileName, json);
        }

        public static void readFromFile(Client toRead)
        {
            string fileName = "clients/" + toRead.name + toRead.lastName + ".txt";
            string text = System.IO.File.ReadAllText(fileName);
            toRead = JsonConvert.DeserializeObject<Client>(text);
        }
    }
}