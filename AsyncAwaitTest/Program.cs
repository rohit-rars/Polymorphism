using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwaitTest
{
    /*
     * Asynchronous programming is very popular with the help of the async and await keywords in C#. When we are dealing with UI, 
     * and on button click, we use a long-running method like reading a large file or something else which will take a long time, 
     * in that case, the entire application must wait to complete the whole task. In other words, if any process is blocked in a 
     * synchronous application, the whole application gets blocked, and our application stops responding until the whole task completes.
     * 
     * Asynchronous programming is very helpful in this condition. By using Asynchronous programming, the Application can continue 
     * with the other work that does not depend on the completion of the entire task.
     */
    class Program
    {
        static void Main(string[] args)
        {
            callMethod();
            Console.ReadKey();
        }

        public static async void callMethod()
        {
            Method2();
            int count = await Method1();
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });

            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
                // Do something
                Task.Delay(100).Wait();
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
