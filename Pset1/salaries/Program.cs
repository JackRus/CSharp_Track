using System;
using System.Collections.Generic;

namespace salaries
{

    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public void increase(int percent)
        {
            this.Salary += this.Salary * percent / 100;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // instances of the employees
            Employee person1 = new Employee();
            person1.Name = "Jenny Penny";
            person1.Salary = 2000;

            Employee person2 = new Employee();
            person2.Name = "Lolly Polly";
            person2.Salary = 2500;

            Employee person3 = new Employee();
            person3.Name = "Peter Meter";
            person3.Salary = 3000;

            List<Employee> employees = new List<Employee> {
                person1, person2, person3,
            };
            
            Console.WriteLine("Current salaries are:");
            printSalaries(employees);

            // Increase everybody's salary 
            increaseAll(employees);

            Console.WriteLine("\nNew salaries are:");
            printSalaries(employees);   
        }

        static void printSalaries (List<Employee> workers) {
           foreach(Employee worker in workers){
                Console.WriteLine("--> {0}: {1:C2}", worker.Name, worker.Salary);
            } 
        }
        static void increaseAll(List<Employee> all)
        {
            int percent;

            do {
                Console.Write("What is the salaries increase: ");
                if (!int.TryParse(Console.ReadLine(), out percent))
                {
                    percent = -1;
                }
            } while (percent < 0);
            
            foreach(Employee worker in all)
            {
                worker.increase(percent);
            }
        }
    }
}