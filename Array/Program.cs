using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArr = { 10, 324, 45, 90, 9808 };
            FindMinimum(myArr);
            FindMaximum(myArr);
            SortArray(myArr);
            Console.ReadKey();
        }

        private static void SortArray(int[] arr)
        {
            int temp;

            //Des
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;

                    }
                }
            }

            Console.WriteLine("Sorted (Descending Order) Array elements: ");
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            //Asc
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;

                    }
                }
            }

            Console.WriteLine("Sorted (Ascending Order) Array elements: ");
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void FindMinimum(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("Minimum value in array is: " + min);
        }

        private static void FindMaximum(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine("Maximum value in array is: " + max);
        }
    }
}
