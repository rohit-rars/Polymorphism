using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingMultithreading multithreading = new TestingMultithreading();
            Thread thread1 = new Thread(multithreading.Method1);
            Thread thread2 = new Thread(multithreading.Method2);
            thread1.Start();
            thread2.Start();
            thread2.Abort
            Console.ReadKey();
        }

        public class TestingMultithreading
        {
            public void Method1()
            {
                // It prints numbers from 0 to 10 
                for (int I = 0; I <= 10; I++)
                {
                    Console.WriteLine("Method1 is : {0}", I);

                    // When the value of I is equal to 5 then 
                    // this method sleeps for 6 seconds 
                    if (I == 5)
                    {
                        Thread.Sleep(6000);
                    }
                }
            }

            public void Method2()
            {
                // It prints numbers from 0 to 10 
                for (int J = 0; J <= 10; J++)
                {
                    Console.WriteLine("Method2 is : {0}", J);
                }
            }
        }
    }
}
