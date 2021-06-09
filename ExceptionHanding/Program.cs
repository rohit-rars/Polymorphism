using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHanding
{
    class Program
    {
        /*
         * throw : If we use "throw" statement, it preserve original error stack information. In exception handling "throw" 
         * with empty parameter is also called re-throwing the last exception.
         * 
         * throw ex : If we use "throw ex" statement, stack trace of exception will be replaced with a stack trace starting 
         * at the re-throw point. It is used to intentionally hide stack trace information
         * 
         * So it is good practice to use the "throw" statement, rather than "throw ex" because it will give us more accurate 
         * stack information rather than "throw ex"
         */
        static void Main(string[] args)
        {
            Class1 cls1 = new Class1();
            Console.WriteLine(cls1.Method1());
            Console.Read();
        }

        class Class1
        {
            public String Method1()
            {
                try
                {
                    Class2 cls2 = new Class2();
                    return cls2.Method2();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----Stack Trace for the Exception Occurred------");
                    Console.WriteLine(ex.StackTrace.ToString());
                    Console.WriteLine("-------Method in which Exception Occurred------");
                    Console.WriteLine(ex.TargetSite.ToString());
                }
                return "";
            }
        }

        class Class2
        {
            public String Method2()
            {
                try
                {
                    FaultyMethod2();
                    return "Method2 called";
                }
                catch (Exception ex)
                {
                    throw;
                    //throw ex;
                }
            }

            //This method is responsible for the exception  
            public void FaultyMethod2()
            {
                throw new TimeoutException();
            }
        }
    }
}
