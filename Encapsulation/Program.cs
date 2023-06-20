using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    /*
     * Encapsulation is defined as the wrapping up of data under a single unit. It is the mechanism that binds together code and the 
        data it manipulates. In a different way, encapsulation is a protective shield that prevents the data from being accessed by the 
        code outside this shield.

     * Technically in encapsulation, the variables or data of a class are hidden from any other class and can be accessed only through 
        any member function of own class in which they are declared.
     
     *Encapsulation can be achieved by: Declaring all the variables in the class as private and using C# Properties in the class to set 
        and get the values of variables.
     */
    class Program
    {
        static void Main(string[] args)
        {
            // creating object 
            DemoEncap obj = new DemoEncap();

            obj.Name = "Rohit";
            obj.Age = 31;
            Console.WriteLine("Name: " + obj.Name);
            Console.WriteLine("Age: " + obj.Age);
        }
    }

    public class DemoEncap
    {
        private string studentName;
        private int studentAge;

        public string Name
        {
            get
            {
                return studentName;
            }

            set
            {
                studentName = value;
            }
        }

        public int Age
        {
            get
            {
                return studentAge;
            }

            set
            {
                studentAge = value;
            }
        }
    }
}
