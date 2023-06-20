using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adapter
{
    /*
     * Adapter design pattern is used between incompatible interfaces. It converts the 
     * incompatible interface into a compatible interface which can be used by client.
     * So we can say that adapter design pattern is used to allow two incompatible interface to communicate. 
     * The adapter play the role of converter or translator.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] temp = { 1, 1, 2, 3 };
            Console.WriteLine(temp.First(x => x == 1));
            Console.WriteLine(temp.Single(x => x == 1));
            ThirdParyAPI thirdParyAPI = new ThirdParyAPI();
            var result = thirdParyAPI.GetXML();
            Console.WriteLine(result);

            var jsonResult = new XmlToJsonAdapter(thirdParyAPI).ConvertXmlToJson();
            Console.WriteLine(jsonResult);
            Console.ReadKey();
        }

        #region BeforeAdapter

        public class ThirdParyAPI
        {
            public XDocument GetXML()
            {
                var xDocument = new XDocument();
                var xElement = new XElement("Customers");
                var xAttributes = CustomerDataProvider.GetData()
                    .Select(m => new XElement("Customer",
                                        new XAttribute("City", m.City),
                                        new XAttribute("Name", m.Name),
                                        new XAttribute("Address", m.Address)));

                xElement.Add(xAttributes);
                xDocument.Add(xElement);
                return xDocument;
            }
        }

        public class Customer
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
        }

        public static class CustomerDataProvider
        {
            public static List<Customer> GetData() => new List<Customer>
            {
                new Customer { City = "Italy", Name = "Alfa Romeo", Address = "Address1" },
                new Customer { City = "UK", Name = "Aston Martin", Address = "Address1"  },
                new Customer { City = "USA", Name = "Dodge", Address = "Address1"  },
                new Customer { City = "Japan", Name = "Subaru", Address = "Address1"  },
                new Customer { City = "Germany", Name = "BMW", Address = "Address1"  }
            };
        }

        #endregion BeforeAdapter

        #region AfterAdapter

        public interface IConvertor
        {
            string ConvertXmlToJson();
        }

        public class XmlToJsonAdapter : IConvertor
        {
            private readonly ThirdParyAPI _xmlConverter;

            public XmlToJsonAdapter(ThirdParyAPI xmlConverter)
            {
                _xmlConverter = xmlConverter;
            }

            public string ConvertXmlToJson()
            {

                string jsonText = JsonConvert.SerializeXNode(_xmlConverter.GetXML());
                var xml = JsonConvert.DeserializeXmlNode(jsonText);
                return jsonText;
            }
        }

        #endregion AfterAdapter
    }
}
