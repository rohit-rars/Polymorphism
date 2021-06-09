using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependInjeUnity
{
    class DataAccessLayer : IProduct
    {
        public string InsertData()
        {
            string value = "Dependency Injection Data Access Layer";
            Console.WriteLine(value);
            return value;
        }
    }
}
