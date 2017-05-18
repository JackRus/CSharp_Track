using System;
using System.Collections.Generic;

namespace bank
{
    public class Account
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastName { get; set; }
        public double Rate { get; set; }
        public int Funds { get; set; }
        public List<Transaction> transactions{ get; set; }

        public static string selectType()
        {
            int value = Program.yesNo("What type of account would you like to open?", "Saving", "Cheking", true);
            string type = value == 1 ? "Saving" : "Checking";
            return type;
        }

        public void AddTransaction (double money, string type)
        {
            Transaction toAdd = new Transaction();
            toAdd.Date = DateTime.Now.ToString("yyyy-MM-dd:mm");
            toAdd.Time = DateTime.Now.ToString("HH:mm");
            toAdd.Amount = money;
            toAdd.Type = type;
            transactions.Add(toAdd);
        }

        public void PrintInfo ()
        {
            Program.header();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "----------------------------------------");
            Console.WriteLine($"Detailed info for account# {this.Number}");
            Console.WriteLine( "----------------------------------------");
            Console.ResetColor();
            Console.WriteLine($"Type: {Type}, Rate: {Rate}%, Owner: {OwnerName} {OwnerLastName}, Opened: {transactions[0].Date}");


            Console.WriteLine($" #   {"Date", -17}{"Time", -11}{"Amount", -7}{"Type", -14}");
            Console.WriteLine($"---------------------------------------------------");
            
            int count = 0;  // index in the table
            string index = "";  // index to string
            string funds = "";

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Transaction t in transactions)
            {
                count++;
                index = $"[{count}]";
                funds = $"{t.Amount:C2}";
                Console.Write($"{index, -5}{t.Date, -17}{t.Time, - 11}{funds, -7}{t.Type, -14}");
                Console.Write("\n");
            }
            Console.ResetColor();
            Console.WriteLine($"---------------------------------------------------\n");
        }

    }
    public class Transaction
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; } 
    }
}