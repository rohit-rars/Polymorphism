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
            
        }
        static void Main(string[] args)
        {
            //int[] arr = { 4, 8, 10, 2, 7, 5, 9 };
            //int n = arr.Length;
            //Console.Write("Minimum number of jumps to reach end is "
            //              + minJumps(arr, 0, n - 1));

            //My_Family fam = new My_Member();
            //fam.member();
            Base b = new Derived();
            b.Show();
            Console.ReadLine();
        }

        static int minJumps(int[] arr, int l, int h)
        {
            // Base case: when source
            // and destination are same
            if (h == l)
                return 0;

            // When nothing is reachable
            // from the given source
            if (arr[l] == 0)
                return int.MaxValue;

            // Traverse through all the points
            // reachable from arr[l]. Recursively
            // get the minimum number of jumps
            // needed to reach arr[h] from these
            // reachable points.
            int min = int.MaxValue;
            for (int i = l + 1; i <= h && i <= l + arr[l]; i++)
            {
                int jumps = minJumps(arr, i, h);
                if (jumps != int.MaxValue && jumps + 1 < min)
                    min = jumps + 1;
            }
            return min;
        }

        public static List<string> PossibleIps(string str)
        {
            List<string> ipList = new List<string>();
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
                            ipList.Add(tempString);
                        }

                        tempString = str;
                    }
                }
            }

            return ipList;
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
            public void member()
            {
                Console.WriteLine("Total number of family members: 3");
            }
        }

        // Derived Class
        public class My_Member : My_Family
        {


            public new void member()
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
