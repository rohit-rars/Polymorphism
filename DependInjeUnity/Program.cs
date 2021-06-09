using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DependInjeUnity
{
    class Program
    {
        /*
         * The Dependency Inversion principle says that components that depend on each other 
         * should interact via an abstraction, not directly with a concrete implementation.
         * 
         * Example: If we have a data access layer and business layer then they should not
         * directly depend on each other, they should depend on an interface or abstract for
         * object creation.
         * 
         * Inversion of control is principal and Dependency Injection is implementation.
         */
        static void Main(string[] args)
        {
            /*Creating a Unity Container*/
            UnityContainer unityContainer = new UnityContainer();

            /*
             * Register a type
             * In this, I am injecting a DA (Data Access) layer into the BL (Business Logic) 
             * layer. That is why I registered both types.
             */
            unityContainer.RegisterType<BusinessLayer>();
            unityContainer.RegisterType<DataAccessLayer>();

            /*
             * Register a type with specific members to be injected.
             * From: Type that will be requested.
             * To: Type that will actually be returned.
             * 
             * You call the RegisterType method to specify the registered type 
             * as an interface or object type and the target type you want to 
             * be returned in response to a query for that type. The target type 
             * must implement the interface, or inherit from the class, that you 
             * specify as the registered type.
             */
            unityContainer.RegisterType<IProduct, DataAccessLayer>();

            /* 
             * Resolve. (Resolve an instance of the default requested type from the container.)
             * We want to resolve the BL by injecting a DL. That is why I wrote Resolve<BL>( );.
             */
            BusinessLayer bl = unityContainer.Resolve<BusinessLayer>();

            /*
             * Finally calling the method.
             */
            bl.Insert();
            Console.ReadKey();
        }
    }
}
