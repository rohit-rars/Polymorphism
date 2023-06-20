using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /*Singleton is a creational design pattern, which ensures that only one object of its kind exists and provides a single 
     * point of access to it for any other code.
        A single constructor, which is private and parameterless. This prevents other classes from instantiating it 
        (which would be a violation of the pattern). Note that it also prevents subclassing - if a singleton can be subclassed once, 
        it can be subclassed twice, and if each of those subclasses can create an instance, the pattern is violated. 
        The factory pattern can be used if you need a single instance of a base type, but the exact type isn't known until runtime.
        
        The class is sealed. This is unnecessary, strictly speaking, due to the above point, but may help the JIT to optimise things more.
        
        A static variable which holds a reference to the single created instance, if any.
        
        A public static means of getting the reference to the single created instance, creating one if necessary.

        The class should be declared as sealed which will ensure that it cannot be inherited.

        Use of Singleton Design Patteren:

        Facades: You can also create Database connections as Singleton which can improve the 
        performance of the application.

        Logs: In an application, performing the I/O operation on a file is an expensive operation. 
        If you create your Logger as Singleton then it will improve the performance of the I/O operation.

        Data sharing: If you have any constant values or configuration values then you can keep these
        values in Singleton So that these can be read by other components of the application.

        Design Pattern will make application reliable, Maintainable and Scalable.
        
        Design patterens are reusable solution to the problems that we encounter in day today progrmming.
        they are generally targeted as solving the problem of object generation and integration. In other 
        words design patterns acts as templates which can be applied to the real world programming problems.
        
         */
    class Program
    {
        static void Main(string[] args)
        {
            // Normal Implementation
            Singleton fromManager = Singleton.SingleInstance;
            fromManager.LogMessage("Request Message from Manager");

            Singleton fromEmployee = Singleton.SingleInstance;
            fromEmployee.LogMessage("Request Message from Employee");
            

            //Parallel Invoke of multiple methods.
            Parallel.Invoke(() => LogManagerRequest(), () => LogEmployeeRequest());
            Console.ReadLine();
        }

        private static void LogManagerRequest()
        {
            Singleton fromManager = Singleton.SingleInstance;
            fromManager.LogMessage("Request Message from Manager Parallel.");
        }

        private static void LogEmployeeRequest()
        {
            Singleton fromEmployee = Singleton.SingleInstance;
            fromEmployee.LogMessage("Request Message from Employee Parallel.");
        }


        public sealed class Singleton
        {
            static int instanceCounter = 0;
            private static Singleton singleInstance = null;

            //For Thread Safe
            private static readonly object lockObject = new object();

            private Singleton()
            {
                instanceCounter++;
                Console.WriteLine("Instances created " + instanceCounter);
            }

            public static Singleton SingleInstance
            {
                get
                {
                    lock (lockObject) // Thread Safety
                    {
                        // Lazy Loading.
                        if (singleInstance == null)
                        {
                            singleInstance = new Singleton();
                        }
                    }

                    return singleInstance;
                }
            }

            public void LogMessage(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
