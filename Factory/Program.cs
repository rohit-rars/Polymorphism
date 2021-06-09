using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /*
     * Factory Design Pattern is a type of Creational Design Pattern. Creational Design 
     * Pattern deals with the creation of the objects such that they can be decoupled 
     * from their implementing system. Using this design pattern, it is very easy to decide 
       which objects need to be created for a given scenario.
    
     * Factory Pattern returns an instance of one of the several possible classes, depending
     * on the data. Factory pattern accepts a parameter and depending on this parameter, 
     * it returns one of the several possible classes. These possible classes have the 
       same parent class and method but each has a different implementation.
     */

    class Program
    {
        static void Main(string[] args)
        {
            iMainInterface scooter = Factory.MyFactory("Scooter");
            scooter.Drive(10);

            iMainInterface bike = Factory.MyFactory("Bike");
            bike.Drive(20);

            Console.ReadKey();
        }

        public static class Factory
        {
            public static iMainInterface MyFactory(string Vehicle)
            {
                switch (Vehicle)
                {
                    case "Scooter":
                        return new Scooter();
                    case "Bike":
                        return new Bike();
                    default:
                        throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
                }
            }
        }

        public interface iMainInterface
        {
            void Drive(int miles);
        }

        /// <summary>
        /// A 'ConcreteProduct' class
        /// </summary>
        public class Scooter : iMainInterface
        {
            public void Drive(int miles)
            {
                Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
            }

            public void ScooterDisplay()
            {
                Console.WriteLine("Scooter Display Method.");
            }
        }

        public class Bike : iMainInterface
        {
            public void Drive(int miles)
            {
                Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
            }

            public void BikeDisplay()
            {
                Console.WriteLine("Bike Display Method.");
            }
        }
    }
}
