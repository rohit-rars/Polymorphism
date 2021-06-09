using System;

namespace Sealed
{
    /*
     * Sealed classes are used to restrict the users from inheriting the class. A class can be 
     * sealed by using the sealed keyword. The keyword tells the compiler that the class is 
     * sealed, and therefore, cannot be extended. No class can be derived from a sealed class.
     */
    class Program
    {
        static void Main(string[] args)
        {

            TestSealed1 t1 = new TestSealed1();
            t1.display();
            Console.ReadLine();
        }
    }

    interface i
    {
        public void display();
    }

    class TestSealed
    {
        public void display()
        {
            Console.WriteLine("Base");
        }
    }

    class TestSealed1 : TestSealed, i
    {
        public new void display()
        {
            Console.WriteLine("Der");
        }

    }
}
