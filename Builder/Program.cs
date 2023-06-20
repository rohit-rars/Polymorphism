using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Builder
{
    internal class Program
    {
        // 1. Builder pattern //
        //  Builder pattern builds a complex object by using a step by step approach. Builder interface defines the steps
        //  to build the final object. This builder is independent of the objects creation process. 

        // 2. Prototype design pattern //
        //  Prototype design pattern is used to create a duplicate object or clone of the current object to enhance performance.
        //  This pattern is used when the creation of an object is costly or complex.

        //  For Example, An object is to be created after a costly database operation.We can cache the object, returns its clone
        //  on next request and update the database as and when needed thus reducing database calls.


        static void Main(string[] args)
        {
            var vehicleCreator = new VehicleCreator(new HeroBuilder());
            vehicleCreator.CreateVehicle();
            var vehicle = vehicleCreator.GetVehicle();
            vehicle.ShowInfo();
            Console.ReadKey();
        }

        public interface IVehicleBuilder
        {
            void SetModel();
            void SetEngine();
            void SetTransmission();
            void SetBody();
            void SetAccessories();

            Vehicle GetVehicle();
        }

        /// <summary>
        /// The 'ConcreteBuilder1' class
        /// </summary>
        public class HeroBuilder : IVehicleBuilder
        {
            Vehicle objVehicle = new Vehicle();
            public void SetModel()
            {
                objVehicle.Model = "Hero";
            }

            public void SetEngine()
            {
                objVehicle.Engine = "4 Stroke";
            }

            public void SetTransmission()
            {
                objVehicle.Transmission = "120 km/hr";
            }

            public void SetBody()
            {
                objVehicle.Body = "Plastic";
            }

            public void SetAccessories()
            {
                objVehicle.Accessories.Add("Seat Cover");
                objVehicle.Accessories.Add("Rear Mirror");
            }

            public Vehicle GetVehicle()
            {
                return objVehicle;
            }
        }

        public class VehicleCreator
        {
            private readonly IVehicleBuilder objBuilder;

            public VehicleCreator(IVehicleBuilder builder)
            {
                objBuilder = builder;
            }

            public void CreateVehicle()
            {
                objBuilder.SetModel();
                objBuilder.SetEngine();
                objBuilder.SetBody();
                objBuilder.SetTransmission();
                objBuilder.SetAccessories();
            }

            public Vehicle GetVehicle()
            {
                return objBuilder.GetVehicle();
            }
        }

        /// <summary>
        /// The 'Product' class
        /// </summary>
        public class Vehicle
        {
            public string Model { get; set; }
            public string Engine { get; set; }
            public string Transmission { get; set; }
            public string Body { get; set; }
            public List<string> Accessories { get; set; }

            public Vehicle()
            {
                Accessories = new List<string>();
            }

            public void ShowInfo()
            {
                Console.WriteLine("Model: {0}", Model);
                Console.WriteLine("Engine: {0}", Engine);
                Console.WriteLine("Body: {0}", Body);
                Console.WriteLine("Transmission: {0}", Transmission);
                Console.WriteLine("Accessories:");
                foreach (var accessory in Accessories)
                {
                    Console.WriteLine("\t{0}", accessory);
                }
            }
        }
    }
}
