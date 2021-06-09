using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticPoly sp = new StaticPoly();
            var test = sp.Calc(10, 20);
            var test1 = sp.Calc(10, 20, 30);

            Console.WriteLine(test);
            Console.WriteLine(test1);


            RunTimePolyBase child = new RunTimePolyChild();
            child.Display();

            Console.ReadKey();
        }

        class RunTimePolyBase
        {
            public RunTimePolyBase()
            {
                Console.WriteLine("In Base Class Constructor.");
            }

            public virtual void Display()
            {
                Console.WriteLine("In Base Class Display Method");
            }
        }

        class RunTimePolyChild : RunTimePolyBase
        {
            public RunTimePolyChild()
            {
                Console.WriteLine("In Child Class Constructor.");
            }

            public override void Display()
            {
                Console.WriteLine("In Child Class Display Method");
            }
        }

        class StaticPoly
        {
            public int Calc(int i, int j)
            {
                return i * j;
            }

            public int Calc(int i, int j, int k)
            {
                return i * j + k;
            }
        }
    }
}
