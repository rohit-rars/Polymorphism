using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingAndOverriding
{
    /*
     * Method overriding allows a subclass to provide a specific implementation 
     * of a method that is already provided by base class. The implementation
     * in the subclass overrides (replaces) the implementation in the base class.
     * 
     * The important thing to remember about overriding is that the method that 
     * is doing the overriding is related to the method in the base class.
     */
    class Program
    {
        public static void Print(ref int b)
        {
            Console.WriteLine(b);
        }
        public static void Print(double a, double b)
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
        static void Main(string[] args)
        {
            PossibleIps("12345");
            Console.ReadLine();
        }

        public static void PossibleIps(string str)
        {
            //List<string> ipList = new List<string>();
            int len = str.Length;
            string tempString = str;
            for (int i = 1; i < len - 2; i++)
            {
                for (int j = i + 1; j < len - 1; j++)
                {
                    for (int k = j + 1; k < len; k++)
                    {
                        tempString = tempString.Substring(0, k) + "." + tempString.Substring(k);
                        tempString = tempString.Substring(0, j) + "." + tempString.Substring(j);
                        tempString = tempString.Substring(0, i) + "." + tempString.Substring(i);

                        if (CheckIp(tempString))
                        {
                            Console.WriteLine("Vaild Ip: " + tempString);
                            //ipList.Add(tempString);
                        }

                        tempString = str;
                    }
                }
            }

            //return ipList;
        }

        public static bool CheckIp(string strIp)
        {
            string[] tempArray = strIp.Split('.');
            foreach (var tempIp in tempArray)
            {
                int i;
                if (tempIp.Length > 3 || !int.TryParse(tempIp, out i) || i < 0 || i > 255)
                    return false;
                if (tempIp.Length > 1 && i == 0)
                    return false;
                if (tempIp.Length > 1 && i != 0
                    && tempIp[0] == '0')
                    return false;
            }

            return true;
        }

        // Base Class
        public class My_Family
        {
            public virtual void member()
            {
                Console.WriteLine("Total number of family members: 3");
            }
        }

        // Derived Class
        public class My_Member : My_Family
        {


            public override void member()
            {

                // Calling the hidden method of the
                // base class in a derived class
                // Using base keyword
                Console.WriteLine("Name: Rakesh, Age: 40 \nName: Somya," +
                                      " Age: 39 \nName: Rohan, Age: 20");
            }
        }

        public class Base
        {
            public virtual void Show()
            {
                Console.WriteLine("Show From Base Class.");
            }
        }

        public class Derived : Base
        {
            //the keyword "override" change the base class method.
            public override void Show()
            {
                Console.WriteLine("Show From Derived Class.");
            }
        }

        public class ClassA
        {
            public void print()
            {
                Console.WriteLine("Hi ClassA");
            }
        }

        public class ClassB : ClassA
        {
            public void print()
            {
                Console.WriteLine("Hi ClassA");
            }
        }

        public class ClassC : ClassB
        {
            public void print()
            {
                Console.WriteLine("Hi ClassA");
            }
        }


        public class BaseOverRiding
        {
            public virtual void Show()
            {
                Console.WriteLine("Show From Base Class.");
            }
        }

        public class DerivedverRiding : BaseOverRiding
        {
            public new void Show()
            {
                Console.WriteLine("Show From Derived Class.");
            }
        }
    }
}
