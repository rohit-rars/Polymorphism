using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPL
{
    /*
     * The Task Parallel Library (TPL) is a set of public types and APIs in the System.Threading and System.Threading.Tasks namespaces.
     * The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to applications.
     * 
     * In Multithreading, it uses the single core of the processor. With this we may not achive the full benefit of multi core processor.
     * Task Parl. Lib runs the each task parllely into different core of processor. 
     * 
     * Data parallelism refers to scenarios in which the same operation is performed concurrently (that is, in parallel) on elements in a source 
     * collection or array. In data parallel operations, the source collection is partitioned so that multiple threads can operate on different 
     * segments concurrently. The Task Parallel Library (TPL) supports data parallelism through the System.Threading.Tasks.Parallel class. 
     * This class provides method-based parallel implementations of for and foreach loops
     * 
     * 
     * .NET framework provides Threading.Tasks class to let you create tasks and run them asynchronously. A task is an object that represents some 
     * work that should be done. The task can tell you if the work is completed and if the operation returns a result, the task gives you the result.
     * 
     * .NET Framework has thread-associated classes in System.Threading namespace.  A Thread is a small set of executable instructions.
     * 
     * -- Difference
     * The Thread class is used for creating and manipulating a thread in Windows. A Task represents some asynchronous operation and is
     * part of the Task 
     * Parallel Library, a set of APIs for running tasks asynchronously and in parallel.
     * 
     * The task can return a result. There is no direct mechanism to return the result from a thread.
     * 
     * Task supports cancellation through the use of cancellation tokens. But Thread doesn't.
     * 
     * A task can have multiple processes happening at the same time. Threads can only have one task running at a time.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() => DoWork(1, 2000));
            Task t2 = Task.Factory.StartNew(() => DoWork(2, 2000));
            Task t3 = Task.Factory.StartNew(() => DoWork(3, 2000));

            //int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Parallel.For(0, 10, i =>
            //{
            //    Console.WriteLine("i = " + i);
            //    Thread.Sleep(1000);
            //});

            Console.ReadKey();
        }

        static void DoWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is begnning...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} is completed...", id);
        }
    }
}
