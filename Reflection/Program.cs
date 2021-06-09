using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        /*
         * Reflection objects are used for obtaining type information at runtime. The classes that give access to 
         * the metadata of a running program are in the System.Reflection namespace.
         * 
         * The System.Reflection namespace contains classes that allow you to obtain information about the application 
         * and to dynamically add types, values, and objects to the application.
         * 
         * Reflection has the following applications −
         * It allows view attribute information at runtime.
         * It allows late binding to methods and properties.
         * It allows creating new types at runtime and then performs some tasks using those types.
         */
        static void Main(string[] args)
        {
            Assembly executing = Assembly.GetExecutingAssembly();
            // Array to store types of the assembly
            Type[] types = executing.GetTypes();

            foreach (var item in types)
            {
                // Display each type
                Console.WriteLine("Class : {0}", item.Name);

                // Array to store methods
                MethodInfo[] methods = item.GetMethods();
                foreach (var method in methods)
                {
                    // Display each method
                    Console.WriteLine("--> Method : {0}", method.Name);

                    // Array to store parameters
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var arg in parameters)
                    {
                        // Display each parameter
                        Console.WriteLine("----> Parameter : {0} Type : {1}",
                                                arg.Name, arg.ParameterType);
                    }
                }
            }

            Console.ReadKey();
        }

        [HelpAttribute("Information on the class MyClass")]
        class TestReflection
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public TestReflection()
            {
                ID = 0;
                Name = "Test";
            }

            public TestReflection(int id, string name)
            {
                ID = id;
                Name = name;
            }

            // Method to Display Data
            public void displayData()
            {
                Console.WriteLine("ID : {0}", ID);
                Console.WriteLine("Name : {0}", Name);
            }
        }

        [AttributeUsage(AttributeTargets.All)]
        public class HelpAttribute : System.Attribute
        {
            public readonly string Url;

            public string Topic
            {
                get
                {
                    return topic;
                }
                set
                {
                    topic = value;
                }
            }
            public HelpAttribute(string url)
            {
                this.Url = url;
            }
            private string topic;
        }
    }
}
