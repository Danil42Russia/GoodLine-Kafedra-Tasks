using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            List<string> arr = new List<string>((str.Substring(str.IndexOf('"') + 1, str.LastIndexOf('"') - 1)).Split(' '));

            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }
        }
    }
}
