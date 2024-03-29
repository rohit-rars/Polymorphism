﻿using System;

namespace AbstractAndInterface
{
    /*
     * An Interface looks like a class, it contain only the declaration of the members but 
     * has no implementation. It provides a contract specifying how to create an Object,
     * without caring about the specifics of how they do the things. An Interface is a reference 
     * type and it included only the signatures of methods, properties, events or indexers. 
     * In order to implement an interface member, the corresponding member of the implementing 
     * class should be public , non-static , and have the same name and signature as the
     * interface member. 
     * 
     * The "diamond problem" is an ambiguity that arises when two classes B and C inherit from A, 
     * and class D inherits from both B and C. If there is a method in A that B and C have overridden, 
     * and D does not override it, then which class of the method does D inherit: that of B, or that 
     * of C? So this is an ambiguity problem in multiple inheritances in c#. So that c# does not support 
     * multiple inheritances. It also called an ambiguity problem in c#.
     * 
     * C# does not support multiple inheritance , because they reasoned that adding multiple 
     * inheritance added too much complexity to C# while providing too little benefit. In C#, 
     * the classes are only allowed to inherit from a single parent class, which is called
     * single inheritance . But you can use interfaces or a combination of one class and 
     * interface(s), where interface(s) should be followed by class name in the signature.
     */
    class Program
    {
        static void Main(string[] args)
        {
            iBase baseObj = new SampleClass();
            baseObj.Display();

            iChild childObj = new SampleClass();
            childObj.Display();

            Console.ReadKey();
        }

        public interface iBase
        {
            void Display();
        }

        public interface iChild
        {
            void Display();
        }

        public class SampleClass : iBase, iChild
        {
            void iBase.Display()
            {
                Console.WriteLine("Base.Display");
            }

            void iChild.Display()
            {
                Console.WriteLine("Child.Display");
            }
        }
    }
}
