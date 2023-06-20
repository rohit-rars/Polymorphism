using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        /*
         * 
         *.NET Framework's Reflection API allows you to fetch Type (Assembly) information at runtime or programmatically. 
         * We can also implement late binding using .NET Reflection. At runtime, Reflection uses the PE file to read the 
         * metadata about an assembly. Reflection enables you to use code that was not available at compile time. .
         * 
         * Generic means the general form, not specific. In C#, generic means not specific to a particular data type.
         * 
         * C# allows you to define generic classes, interfaces, abstract classes, fields, methods, static methods, 
         * properties, events, delegates, and operators using the type parameter and without the specific data type. 
         * A type parameter is a placeholder for a particular type specified when creating an instance of the generic type.
         * 
         * Generics increase the reusability of the code. You don't need to write code to handle different data types.
         * Generics are type-safe. You get compile-time errors if you try to use a different data type than the one specified in the definition.
         * */
        static void Main(string[] args)
        {
            DataStore<string> strStore = new DataStore<string>();
            strStore.Data = "Hello World!";
            //strStore.Data = 123; // compile-time error

            DataStore<int> intStore = new DataStore<int>();
            intStore.Data = 100;
            //intStore.Data = "Hello World!"; // compile-time error
        }

        class DataStore<T>
        {
            //Generic Field
            public T Data { get; set; }

            //Generic Array.
            public T[] data = new T[10];

            //Generic Method
            public void AddOrUpdate(int index, T item)
            {
                if (index >= 0 && index < 10)
                    data[index] = item;
            }
        }

        class Base
        {
            public Base(int i)
            {

            }
        }

        class Child : Base
        {
            public Child(int j) : base(j)
            {

            }
        }

        static class SomeType<T>
        {
            public static T t;

            static SomeType()
            {

            }

            public static void Initialize(T t)
            {
                SomeType<T>.t = t;
            }

            public static T Method()
            {
                return t;
            }
        }
    }
}
