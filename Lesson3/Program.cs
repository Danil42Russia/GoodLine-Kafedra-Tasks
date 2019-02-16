using System;
using System.Collections.Generic;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            SortedSet<string> arr = new SortedSet<string>((str.Substring(str.IndexOf('"') + 1, str.LastIndexOf('"') - 1)).Split(' '));
 
            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }
        }
    }
}
