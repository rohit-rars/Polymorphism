using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystemDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstChain c = new ConstChain(10);

            Console.ReadKey();
        }
    }

    class ConstChain
    {
        public ConstChain() : this(10)
        {
            Console.WriteLine("Default");
        }

        public ConstChain(int i)
        {
            Console.WriteLine("Parameterized");
        }
    }
}
