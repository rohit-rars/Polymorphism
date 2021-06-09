using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticKeyword
{
    class Program
    {
        /*
         * Static methods are not thread safe. if you are passing parameters in static method and not using any
         * local variables from the class then it will not create any issue of cross thread.
         * 
         * Static members are stored in a special area in the memory called High-Frequency Heap. Static members
         * of non-static classes are shared across all the instances of the class. So, the changes done by one
         * instance will be reflected in all the other instances.
         * 
         * Static variables are stored on the Managed Heap, not the Stack, when the type is first referenced.  
         * The Type Object of the compiled class contains a reference to the object. 
         * 
         * The Type Object of a class will stay in memory until the AppDomain where it resides is unloaded. 
         * Since the object on the Heap is always being referenced by the compiled Type Object, static objects
         * on the Heap will never by GC'ed and will always consume memory until the AppDomain is unloaded
         * 
         * Const:
         * Constant fields are defined at the time of declaration in the code snippet, because once they are defined they can't be modified. 
         * By default a constant is static, so you can't define them static from your side.
         * 
         * ReadOnly:
         * A Readonly field can be initialized either at the time of declaration or within the constructor of the same class. We can also
         * change the value of a Readonly at runtime or assign a value to it at runtime (but in a non-static constructor only).
         * 
         * Static:
         * The static keyword is used to declare a static member. If we are declare a class as a static class then in this case all the class 
         * members must be static too. The static keyword can be used effectively with classes, fields, operators, events, methods and so on effectively.
         * 
         * In:
         * The in keyword causes arguments to be passed by reference but ensures the argument is not modified.
         * 
         * in is actually a ref readonly. Generally speaking, there is only one use case where in can be helpful: high performance apps 
         * dealing with lots of large readonly structs.
         * 
         * int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument);     // value is still 44

            void InArgExample(in int number)
            {
                // Uncomment the following line to see error CS8331
                //number = 19;
            }
         * */
        static void Main(string[] args)
        {
            //Parallel Invoke of multiple methods.
            Parallel.Invoke(() => TestStatic.Display1(), () => TestStatic.Display2());
            Console.ReadLine();
        }

        
        static class TestStatic
        {
            static int temp = 0;

            //For Thread Safe
            private static readonly object lockObject = new object();

            public static void Display1()
            {
                lock (lockObject) // Thread Safety
                {
                    for (int i = 0; i < 100; i++)
                    {
                        temp++;
                        Console.WriteLine(string.Format("Display1 {0}", temp));
                    }
                }
            }

            public static void Display2()
            {
                lock (lockObject) // Thread Safety
                {
                    for (int i = 0; i < 100; i++)
                    {
                        temp++;
                        Console.WriteLine(string.Format("Display2 {0}", temp));
                    }
                }
            }
        }
    }
}
