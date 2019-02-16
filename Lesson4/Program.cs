using System;
using System.Collections.Generic;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            List<string> arr = new List<string>((str.Substring(str.IndexOf('"') + 1, str.LastIndexOf('"') - 1)).Split(' '));
            arr.Sort();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var s in arr)
            {
                if (dictionary.ContainsKey(s))
                {
                    ++dictionary[s];
                }
                else
                {
                    dictionary[s] = 1;
                }
            }

            foreach (var elem in dictionary)
            {
                Console.WriteLine(elem.Key + " " + elem.Value);
            }

        }
    }
}
