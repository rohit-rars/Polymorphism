using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingAndOverriding
{
    /*
     * Method overriding allows a subclass to provide a specific implementation 
     * of a method that is already provided by base class. The implementation
     * in the subclass overrides (replaces) the implementation in the base class.
     * 
     * The important thing to remember about overriding is that the method that 
     * is doing the overriding is related to the method in the base class.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Base objBaseRefToDerived = new Derived();
            objBaseRefToDerived.Show();//Output--> Show From Derived Class.

            //BaseOverRiding objBaseRefToDerivedOver = new DerivedverRiding();
            //objBaseRefToDerivedOver.Show();//Output--> Show From Base Class.

            ClassA obj = new ClassB();
            obj.print(); //Hi ClassA

            ClassB Obj1 = new ClassC();
            Obj1.print(); //Hi ClassA

            ClassA Obj2 = new ClassC();
            Obj2.print(); //Hi ClassA

            // Creating the object of the derived class
            My_Member objT = new My_Member();

            // Access the method of derived class
            objT.member();

            Console.ReadLine();
        }

        // Base Class
        public class My_Family
        {
            public void member()
            {
                Console.WriteLine("Total number of family members: 3");
            }
        }

        // Derived Class
        public class My_Member : My_Family
        {


            public void member()
            {

                // Calling the hidden method of the
                // base class in a derived class
                // Using base keyword
                Console.WriteLine("Name: Rakesh, Age: 40 \nName: Somya," +
                                      " Age: 39 \nName: Rohan, Age: 20");
            }
        }

        public class Base
        {
            public virtual void Show()
            {
                Console.WriteLine("Show From Base Class.");
            }
        }

        public class Derived : Base
        {
            //the keyword "override" change the base class method.
            public override void Show()
            {
                Console.WriteLine("Show From Derived Class.");
            }
        }

        public class ClassA
        {
            public void print()
            {
                Console.WriteLine("Hi ClassA");
            }
        }

        public class ClassB : ClassA
        {
            public void print()
            {
                Console.WriteLine("Hi ClassA");
            }
        }

        public class ClassC : ClassB
        {
            public void print()
            {
                Console.WriteLine("Hi ClassA");
            }
        }


        public class BaseOverRiding
        {
            public virtual void Show()
            {
                Console.WriteLine("Show From Base Class.");
            }
        }

        public class DerivedverRiding : BaseOverRiding
        {
            public new void Show()
            {
                Console.WriteLine("Show From Derived Class.");
            }
        }
    }
}
