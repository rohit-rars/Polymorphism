using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    /*Extension methods enable you to "add" methods to existing types without 
     * creating a new derived type, recompiling, 
     * or otherwise modifying the original type. Extension methods are static methods
     * 
     * Extension methods, as the name suggests, are additional methods. Extension methods
     * allow you to inject additional methods without modifying, deriving or recompiling
     * the original class, struct or interface. Extension methods can be added to your own
     * custom class, .NET framework classes, or third party classes or interfaces
     
     */
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder("Rohit");
            int i = 10;
            bool result = i.IsGreaterThan(100, 20);
            Console.WriteLine(result);

            DataStore<string> store = new DataStore<string>();
            Console.ReadKey();
        }
    }

    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value, int val1)
        {
            return i > value;
        }
    }

    class DataStore<T>
    {
        public T Data { get; set; }
    }
}
