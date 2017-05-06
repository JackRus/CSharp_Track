using System;
using System.Collections.Generic;

namespace max
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input;
            do{
            Console.Write("Please provide up to 100 integer numbers, separated with a whitespace: ");
			// gets string from user
            input = Console.ReadLine().Split(' ');
			Console.WriteLine("Max value is: {0}", Max(input));
            } while (input.Length < 1);
		}

		static int Max(string[] array)
		{
			int number;
			int[] numbers = new int[array.Length];
			int index = 0;
			foreach (string temp in array)
			{
				// string to int
                if (int.TryParse(temp, out number))
				{
					numbers[index] = number;
					index++;
				}
			}
            if (index == 0)
            {
                Console.WriteLine("... lloks like you didn't provide any numbers :(");
            }
			int maxValue = numbers[0];
			// search for max int
            for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] > maxValue)
				{
					maxValue = numbers[i];
				}
			}
			return maxValue;
		}
	}
}

