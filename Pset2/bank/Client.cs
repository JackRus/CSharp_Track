using System;
using System.Collections.Generic;

namespace bank
{
    public class Client
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Account> allAccounts { get; set; }

        public void CloseAccount(int index)
        {
            if (allAccounts[index-1].Funds != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[!] This account isn't empty. You have to withdraw all funds in order to close the account!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"Account #{allAccounts[index-1].Number} was SUCCESSFULLY closed");
                Console.WriteLine($"-----------------------------------------------\n");
                Console.ResetColor();
                allAccounts.RemoveAt(index-1);
            }
        }

        public static void OpenAccount(Client myCustomer, string type)
        {
            Account newAccount = new Account();

            // creating unique account number, based on time and date
            DateTime dt = DateTime.Now;
            newAccount.Number = dt.ToString("yyyyMMddHHmmss");
            newAccount.Type = type;
            newAccount.Rate = type == "Saving" ? 1.5 : 0;
            newAccount.OwnerName = myCustomer.name;
            newAccount.OwnerLastName = myCustomer.lastName;
            newAccount.Funds = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Your New Account #: {newAccount.Number}");
            Console.WriteLine($"              Type: {newAccount.Type}");
            Console.WriteLine($"      Interst Rate: {newAccount.Rate}%");
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

        public int listOpen()
        {
            int count = 0;

            if (allAccounts.Count == 0)
            {
                Program.header();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[!] YOU DON'T HAVE ACCOUNTS YET!\n");
                Console.ResetColor(); 
                Program.continueOrExit(name);
                return count;  
            }
            Console.WriteLine($" #   {"Account #", -17}{"Type", -11}{"Rate", -7}{"Funds", -14}");
            Console.WriteLine($"---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            
            string index = "";
            string rate = "";
            string funds = "";
            foreach (Account ac in allAccounts)
            {
                count++;
                index = $"[{count}]";
                rate = ac.Rate + "%";
                funds = $"{ac.Funds:C2}";
                Console.Write($"{index, -5}{ac.Number, -17}{ac.Type, - 11}{rate, -7}{funds, -14}");
                Console.Write("\n");
            }
            Console.ResetColor();
            Console.WriteLine($"---------------------------------------------------\n");
            return count;
        }

        public void Deposit(int index, int amount)
        {
            allAccounts[index-1].Funds += amount;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] Transaction was SUCCESSFULL! New balace: {allAccounts[index-1].Funds:C2}\n");
            Console.ResetColor();
        }

        public int selectClose()
        {
            int index = 0;
            if (allAccounts.Count == 0)
            {
                Program.header();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[!] YOU DON'T HAVE ACCOUNTS TO CLOSE!\n");
                Console.ResetColor(); 
                Program.continueOrExit(name);
                return index;  
            }
            int count;
            do {
                Program.header();
                count = listOpen();
                Console.WriteLine("Which account do you want to close?");
                Console.Write($"\nPlese select a number (1-{count}): ");
                int.TryParse(Console.ReadLine(), out index);
                Console.Clear();
            } while (index < 1 || index > count);

            return index;
        }

        public int selectAndDeposit(out int deposit)
        {
            int index = 0;
            if (allAccounts.Count == 0)
            {
                Program.header();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[!] YOU DON'T HAVE ACCOUNTS YET!\n");
                Console.ResetColor(); 
                Program.continueOrExit(name);
                deposit = 0;
                return index;  
            }
            int count;
            do {
                Program.header();
                count = listOpen();
                Console.WriteLine("Which account would you like to use?");
                Console.Write($"\nPlese select a number (1-{count}): ");
                int.TryParse(Console.ReadLine(), out index);
                if (index < 1 || index > count)
                {
                    Program.header();
                }
            } while (index < 1 || index > count);

            do {
                Program.header();
                listOpen();
                Console.WriteLine($"Account selected: [{index}]");
                Console.WriteLine($"Maximum: $100,000.00 per day ");
                Console.Write($"\nWhat is the deposit amount?: ");
                int.TryParse(Console.ReadLine(), out deposit);
            } while (deposit <= 0 || deposit > 100000);
            return index;
        }

        public static void makeChoice(ref int choice, string name)
        {
            do {
                Program.header();
                Console.WriteLine($"What would you like to do, {name}?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    [1] Open New Account");
                Console.WriteLine("    [2] Close Account");
                Console.WriteLine("    [3] See all my Accounts");
                Console.WriteLine("    [4] Make a Deposit");
                Console.WriteLine("    [5] Withdraw Money");
                Console.WriteLine("    [6] Quit");
                Console.ResetColor();
                Console.Write("\nPlese select a number (1-6): ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.Clear();
            } while (choice < 1 || choice > 6);
        }

        public void askName()
        {
            Console.Write("\nWhat is your FIRST name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            name = Console.ReadLine().Trim();
            Console.ResetColor();

            Console.Write("              LAST name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            lastName = Console.ReadLine().Trim();
            Console.ResetColor();
        }

        public static void thankYou()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n====================================");
            Console.WriteLine($"* Thank you for visiting BIG BANK! *");
            Console.WriteLine("====================================\n\n\n");
            Console.ResetColor();
        }

        public int selectAndWithdraw(out int deposit)
        {
            int index = 0;
            if (allAccounts.Count == 0)
            {
                Program.header();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[!] YOU DON'T HAVE ACCOUNTS YET!\n");
                Console.ResetColor(); 
                Program.continueOrExit(name);
                deposit = 0;
                return index;  
            }

            int count;
            do {
                Program.header();
                count = listOpen();
                Console.WriteLine("Please, make sure you have enough funds on the selected account before you proceed.");
                Console.Write($"\nPlese select a number (1-{count}): ");
                int.TryParse(Console.ReadLine(), out index);
                if (index >= 1 || index <= count)
                {
                    if (allAccounts[index-1].Funds == 0)
                    {
                        
                    }
                }
            } while (index < 1 || index > count);

            do {
                Program.header();
                listOpen();
                Console.WriteLine($"Account selected: [{index}]");
                Console.WriteLine($"Balance:{allAccounts[index-1].Funds:C2}");
                Console.Write($"\nHow much would you like to withdraw?: ");

                bool check = int.TryParse(Console.ReadLine(), out deposit);
                if (!check) deposit = -1; 
            } while (deposit < 0 || deposit > allAccounts[index-1].Funds);
            return index;
        }
    }
}