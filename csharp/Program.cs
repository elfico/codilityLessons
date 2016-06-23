using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class Program
    {
        static string n = "";
        static void Main(string[] args)
        {
            List<int> pos = new List<int>();
            string bin = "";
            int number;
            Console.WriteLine("Enter the number");
            number = int.Parse(Console.ReadLine());

            bin = getBin(number, 2);
            Console.WriteLine(bin);
            
            if(bin.Contains("0") == true)
            {
                // List<int> index = bin.AllIndexes("1");

                List<int> index = AllIndexes(bin, "1");

                for (int i = 0; i < index.Count; i++)
                {
                    Console.WriteLine(index[i]);
                }

                for (int j = 0; j < index.Count - 1; j++)
                {
                    if ((index[j + 1] - index[j]) > 1)
                        Console.WriteLine("gap between {0} and {1} is {2}", index[j], index[j + 1], (index[j + 1] - index[j] - 1));
                    pos.Add(index[j + 1] - index[j] - 1);
                }
                int n = pos.Max();
                Console.WriteLine(n);

                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("No binary gap between");
                Console.ReadKey();
            }
        }

        static string getBin(int num, int numbase)
        {
            
            if (num > 0)
            {
                getBin(num / numbase, numbase);
                n += num % numbase;
            }
           return n;
            
         }

        static List<int> AllIndexes(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

    }
}
