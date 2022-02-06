using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollection
{
    /*
     * The Garbage Collector (GC) is the part of the .NET Framework that allocates and releases memory for your .NET applications.
     * The Common Language Runtime (CLR) manages allocation and deallocation of a managed object in memory. C# programmers never
     * do this directly, there is no delete keyword in the C# language. It relies on the garbage collector.
     * 
     * The .NET objects are allocated to a region of memory termed the managed heap. They will be automatically destroyed by the
     * garbage collector. Heap allocation only occurs when you are creating instances of classes. It eliminates the need for the
     * programmer to manually delete objects that are no longer required for program execution. This reuse of memory helps reduce
     * the amount of total memory that a program needs to run. Objects are allocated in the heap continuously, one after another. 
     * It is a very fast process, since it is just adding a value to a pointer.
     * 
     * The process of releasing memory is called garbage collection. It releases only objects that are no longer being used in the
     * application.
     * 
     * Basically there are 3 generation of garbage collector in c# 
     * 1: Generation 0 All the short-lived objects such as temporary variables are contained in the generation 0 of the heap memory. 
     * All the newly allocated objects are also generation 0 objects implicitly unless they are large objects. In general, the 
     * frequency of garbage collection is the highest in generation 0.
     * 
     * 2: Generation 1 If space occupied by some generation 0 objects that are not released in a garbage collection run, then these
     * objects get moved to generation 1. The objects in this generation are a sort of buffer between the short-lived objects in
     * generation 0 and the long-lived objects in generation 2.
     * 
     * 3: Generation 2 If space occupied by some generation 1 objects that are not released in the next garbage collection run,
     * then these objects get moved to generation 2. The objects in generation 2 are long lived such as static objects as they
     * remain in the heap memory for the whole process duration.
     * 
     * when garbage collector starts for raclaming the memory for newly created object then it fisrt search or try to reclaim 
     * the memory from Geneartion 0 then Generation 1 and then Finally genaration 3
     * 
     * Demo obj = new Demo();
        Console.WriteLine("The generation number of object obj is: "+ GC.GetGeneration(obj));
     * 
     * Finalize method is used to free to the unmanaged resources. As such destructor is used to call the finalize method. we can't
     * directly call the finalize method.
     * 
     * we implement Idisposable interface to keep the control of garage collection. By implementing Dispose method we can
     * can free the memory whenever we want to. can be used to Clean Managed and Unmanaged Resoruces.
     */
    class Program
    {
        static void Main(string[] args)
        {
            TestFinalize test = new TestFinalize();

            using (mycustomclass tempCls = new mycustomclass())
            {

            };

            Console.WriteLine("Hi");
            Console.ReadKey();
        }

        class TestFinalize
        {
            public TestFinalize()
            {
                Console.WriteLine("I am into Constructor");
            }

            ~TestFinalize()
            {
                
                Console.WriteLine("I am into Destructor");
            }
        }

        class mycustomclass : IDisposable
        {
            private static readonly object lockObject = new object();
            private bool disposed = false;
            public void Dispose()
            {
                Dispose(true);
                Console.WriteLine("I am into Dispose");
                GC.SuppressFinalize(this); // Clear the object from finalize queue. Performace wise its good.
            }

            /*
             * Destructors in C# are methods inside the class used to destroy instances of that class when they are no longer needed. 
             * The Destructor is called implicitly by the .NET Framework’s Garbage collector and therefore programmer has no control 
             * as when to invoke the destructor. An instance variable or an object is eligible for destruction when it is no longer reachable.
             */
            ~mycustomclass()
            {
                /* When User forgot to call the dispose method.  Cleanup and release unmanaged resource.
                 * used to free the unmanaged resource (anything that is not developed in .net framework). if you are
                 * using any unmanaged resource then only use the finalize method. finalize method is called by garbage collector.
                 * we don't have any control over finalize method. garbage collector checks the class, if the class 
                 * is having finalize method implemented, it will keep that object in finalize queue. Garabage collector manages 
                 * the finalize queue.  
                 * 
                 */
                Console.WriteLine("I am into finalize");
                Dispose(false);
            }

            protected void Dispose(bool disposing)
            {
                if(!disposed)
                {
                    if (disposing)
                    {
                        // Dispose managed resources.
                    }

                    // Clean Unmanaged Resources.
                }

                disposed = true;
            }
        }
    }
}
