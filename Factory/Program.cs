using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
            Creator mainFactory = new ConcreteCreator();
            var scooter = mainFactory.FactoryMethod("pdf");
            scooter.GetStream();

            var bike = mainFactory.FactoryMethod("csv");
            bike.GetStream();

            Console.ReadKey();
        }

        public interface IBaseFile
        {
            Stream GetStream();
        }

        class PdfFile : IBaseFile
        {
            public Stream GetStream()
            {
                return new MemoryStream();
            }
        }

        class TextFile : IBaseFile
        {
            public Stream GetStream()
            {
                return new MemoryStream();
            }
        }

        class CSVFile : IBaseFile
        {
            public Stream GetStream()
            {
                return new MemoryStream();
            }
        }

        abstract class Creator
        {
            public abstract IBaseFile FactoryMethod(string type);
        }


        class ConcreteCreator : Creator
        {
            public override IBaseFile FactoryMethod(string fileType)
            {
                switch (fileType)
                {
                    case "txt":
                        return new TextFile();
                    case "csv":
                        return new CSVFile();
                    case "pdf":
                        return new PdfFile();
                    default:
                        throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", fileType));
                }
            }
        }
    }
}
