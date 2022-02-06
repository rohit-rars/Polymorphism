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

            // Declaring an integer array of size 11.
            int[] arr1 = { 1, 2, 99, 9, 8,
                    7, 6, 0, 5, 4, 3 };

            // Printing the original Array.
            Console.WriteLine("Original array: " +
                               String.Join(", ", arr1));

            // Sorting the array using a single loop
            arr1 = sortArrays(arr1);

            // Printing the sorted array.
            Console.WriteLine("Sorted array: " +
                               String.Join(", ", arr1));

            // Declaring a String
            String geeks = "GEEKSFORGEEKS";

            // Declaring a character array
            // to store characters of geeks in it.
            char[] arr2 = geeks.ToCharArray();

            // Printing the original Array.
            Console.WriteLine("Original array: [" +
                               String.Join(", ", arr2) + "]");

            // Sorting the array using a single loop
            arr2 = sortStringArrays(arr2);

            // Printing the sorted array.
            Console.WriteLine("Sorted array: [" +
                               String.Join(", ", arr2) + "]");

            string tempString = "rohit arora";
            while(tempString.Length > 0)
            {
                int count = 0;
                for (int i = 0; i < tempString.Length; i++)
                {
                    if(!string.IsNullOrWhiteSpace(tempString[0].ToString()) 
                        && tempString[0].ToString().ToLower() == tempString[i].ToString().ToLower())
                    {
                        count++;
                    }
                }

                if(count > 1)
                {
                    Console.WriteLine(string.Format("{0} Count is: {1}", tempString[0], count));
                }

                tempString = tempString.ToLower().Replace(tempString[0].ToString().ToLower(), string.Empty);
                Console.WriteLine(tempString.Length);
            }
            

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

            // declaring and initializing the array
            int[] arr = new int[] { 1, 9, 6, 7, 5, 9 };

            int temp;

            // traverse 0 to array length
            for (int i = 0; i < arr.Length - 1; i++)

                // traverse i+1 to array length
                for (int j = i + 1; j < arr.Length; j++)

                    // compare array element with 
                    // all next element
                    if (arr[i] > arr[j])
                    {

                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;

                        /* Without using var
                         * a = 10, b = 5;
                         * 
                         * a = a+b; 15
                         * b = a - b; 10
                         * a = a - b; 5
                         */
                    }

            // print all element of array
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }

            Console.ReadKey();
        }

        // Function for Sorting the array
        // using a single loop
        public static int[] sortArrays(int[] arr)
        {

            // Finding the length of array 'arr'
            int length = arr.Length;

            // Sorting using a single loop
            for (int j = 0; j < length - 1; j++)
            {

                // Checking the condition for two
                // simultaneous elements of the array
                if (arr[j] > arr[j + 1])
                {

                    // Swapping the elements.
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    // updating the value of j = -1
                    // so after getting updated for j++
                    // in the loop it becomes 0 and
                    // the loop begins from the start.
                    j = -1;
                }
            }
            return arr;
        }

        public static char[] sortStringArrays(char[] arr)
        {

            // Finding the length of array 'arr'
            int length = arr.Length;

            // Sorting using a single loop
            for (int j = 0; j < arr.Length - 1; j++)
            {

                // Type Conversion of char to int.
                int d1 = arr[j];
                int d2 = arr[j + 1];

                // Comparing the ascii code.
                if (d1 > d2)
                {

                    // Swapping of the characters
                    char temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    j = -1;
                }
            }
            return arr;
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
