using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    /*
     * Abstraction is an important part of object oriented programming. It means that only the required information is 
     * visible to the user and the rest of the information is hidden.
     * 
     * Encapsulation is data hiding(information hiding) while Abstraction is detail hiding(implementation hiding).
     * 
     * When we have the requirement of a class that contains some common properties or methods with some 
     * common properties whose implementation is different for different classes, in that situation, 
     * it's better to use Abstract Class then Interface. Abstract classes provide you the flexibility 
     * to have certain concrete methods and some other methods that the derived classes should implement. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            NonAbstract nonAbstract = new NonAbstract();
            nonAbstract.display();
            nonAbstract.display1();
            nonAbstract.TestMethod();


            a temp1 = new c();
            temp1.display();

            b temp = new c();
            temp.display();

            //temp = temp1; Error: Conversion

            Console.ReadKey();
        }
    }

    abstract class TestAbstract
    {
        public abstract void display();

        public TestAbstract(int i)
        {
            Console.WriteLine("In Abstract class Constructor.");
        }

        public void TestMethod()
        {
            Console.WriteLine("In public test method.");
        }

        public virtual void TestVirtual()
        {

        }
    }

    abstract class TestAbstract1 : TestAbstract
    {
        public TestAbstract1(): base(10)
        { }
        public abstract void display1();
    }

    class NonAbstract : TestAbstract1
    {
        public override void display()
        {
            Console.WriteLine("In Non Abstract Method.");
        }

        public override void display1()
        {
            Console.WriteLine("In Non Abstract Method1.");
        }
    }


    abstract class a
    {
        public abstract void display();
    }

    interface b
    {
        void display();
    }

    class c : a, b
    {
        public override void display()
        {
            Console.WriteLine("In Child Class Display.");
        }

        void b.display()
        {
            Console.WriteLine("In interface Display.");
        }
    }
}
