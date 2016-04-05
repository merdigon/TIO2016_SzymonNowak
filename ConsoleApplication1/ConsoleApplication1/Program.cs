using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            A obj = new B();
            Console.WriteLine(obj.Get());
            Console.ReadLine();
        }
    }

    class A
    {
        public string Get()
        {
            return Foo();
        }

        public virtual string Foo()
        {
            return "A";
        }
    }

    class B : A
    {
        public override string Foo()
        {
            return "B";
        }
    }
}
