using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    /*
     * Dependency Injection (DI) is a software design pattern. It allows us to develop loosely-coupled code. 
     * The intent of Dependency Injection is to make code maintainable. Dependency Injection helps to reduce the tight 
     * coupling among software components. Dependency Injection reduces the hard-coded dependencies among your classes by 
     * injecting those dependencies at run time instead of design time technically.
     * 
     * Dependency Injection:
     * .NET supports the dependency injection (DI) software design pattern, which is a 
     * technique for achieving Inversion of Control (IoC) between classes and their 
     * dependencies. It allows us to develop loosely-coupled code. Dependency Injection 
     * helps to reduce the tight coupling among software components. Dependency Injection 
     * reduces the hard-coded dependencies among your classes by injecting those 
     * dependencies at run time instead of design time technically.
     * 
     * Electronics, such as televisions and refrigerators, need power to function properly. 
     * For a television, a power supply is needed for it to produce images, videos, and sound. 
     * A refrigerator needs a power supply to preserve food.
     * 
     * Changing the power supply source from the main source to a generator should still make 
     * these electronics work because all they need is power — not necessarily power from a 
     * particular predefined source.
     * 
     * A form of dependency injection would be to create devices that are independent of the 
     * type of power source.
      
     
     * The Dependency Injection pattern involves 3 types of classes.
        Client Class: The client class (dependent class) is a class which depends on the service class
        Service Class: The service class (dependency) is a class that provides service to the client class.
        Injector Class: The injector class injects the service class object into the client class.
     */
    class Program
    {
        static void Main(string[] args)
        {
            //creating object

            //passing dependency
            ClientConstructor c1 = new ClientConstructor(new Service1());
            c1.ServeMethod();

            //passing dependency
            c1 = new ClientConstructor(new Service2());
            c1.ServeMethod();

            #region property

            ClientProperty client = new ClientProperty();
            client.Service = new Service1(); //passing dependency
            client.ServeMethod();

            client.Service = new Service2(); //passing dependency
            client.ServeMethod();

            #endregion

            #region method

            ClientMethod clientMethod = new ClientMethod();
            clientMethod.Start(new Service1());
            clientMethod.Start(new Service2());

            #endregion

            Console.ReadKey();

            using(ClientConstructor t = new ClientConstructor(new Service1()))
            {
                
            }
        }

        // Constructor Injection
        public class ClientConstructor : IDisposable
        {
            private IService _service;
            public ClientConstructor(IService service)
            {
                this._service = service;
            }

            public void ServeMethod()
            {
                this._service.Serve();
            }

            public void Dispose()
            {

            }
        }

        //Property/Setter Injection
        public class ClientProperty
        {
            private IService _service;
            public IService Service
            {
                set { this._service = value; }
            }
            public void ServeMethod()
            {
                this._service.Serve();
            }
        }

        //Method Injection
        public class ClientMethod
        {
            private IService _service;
            public void Start(IService service)
            {
                service.Serve();
            }
        }

        public interface IService
        {
            void Serve();
        }

        public class Service1 : IService
        {
            public void Serve() { Console.WriteLine("Service1 Called"); }
        }

        public class Service2 : IService
        {
            public void Serve() { Console.WriteLine("Service2 Called"); }
        }
    }
}
