using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 4; j > i; j--)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k <= i; k++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();
            }

            Console.Write("Enter Number to check for palindrom: ");
            string checkValue = Console.ReadLine();
            int checkforPalidrom = 0;
            if(int.TryParse(checkValue, out checkforPalidrom) && checkforPalidrom > 0)
            {
                int origValue = checkforPalidrom;
                int reversedValue = 0;
                int mod = 0;
                while(checkforPalidrom != 0)
                {
                    mod = checkforPalidrom % 10;
                    reversedValue = reversedValue * 10 + mod;
                    checkforPalidrom = checkforPalidrom / 10;
                }

                if(origValue == reversedValue)
                {
                    Console.Write(string.Format("{0} is palindrome", origValue));
                }
                else
                {
                    Console.Write(string.Format("{0} is not palindrome", origValue));
                }
            }
            else
            {
                Console.WriteLine("Enter Int value greater than 0. Bye.");
            }

            int[] array = new int[] { 5, 19, 2, 1, 56, 90 };
            int foundat = BinarySearchIterative(array, 90);
            if(foundat > -1)
            {
                Console.WriteLine("found at: " + foundat);
            }

            Console.ReadKey();
        }


        public static int BinarySearchIterative(int[] inputArray, int key)
        {
            Array.Sort(inputArray);
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return -1;
        }
    }
}
