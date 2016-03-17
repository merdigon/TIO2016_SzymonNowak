using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Int32.Parse(args[0]);
            int b = Int32.Parse(args[1]);

            int temp;
            int ab = a * b;
            while(b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }

            Console.WriteLine(ab / a);
        }
    }
}
