using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    class Program
    {
        class Temp
        {
            #region BinarySearch

            public static void BinarySearch()
            {
                /*
                 * Time Complexity: The binary search algorithm has a time complexity of O(log n) - Logarithmic, where n is the number of elements in 
                 * the sorted array. This is because at each step, the search space is divided in half, resulting in a logarithmic time 
                 * complexity. It quickly eliminates half of the remaining elements with each comparison, leading to efficient search 
                 * times even for large arrays.
                 * 
                 * Space Complexity: The space complexity of the binary search algorithm is O(1) - Constant, which means it uses constant space. 
                 * The space required is independent of the size of the input array. Binary search only requires a few additional 
                 * variables to keep track of the left and right indices and the midpoint during the search process. It does not require 
                 * any additional data structures or memory allocation proportional to the input size. Hence, the space complexity is constant.
                 */

                int[] array = { 2, 5, 7, 10, 15, 18, 20 };
                int target = 15;

                int left = 0;
                int right = array.Length - 1;
                int index = -1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (array[mid] == target)
                    {
                        index = mid; // Element found at index mid
                        break;
                    }
                    else if (array[mid] < target)
                    {
                        left = mid + 1; // Target is in the right half of the array
                    }
                    else
                    {
                        right = mid - 1; // Target is in the left half of the array
                    }
                }

                if (index != -1)
                {
                    Console.WriteLine("Element found at index: " + index);
                }
                else
                {
                    Console.WriteLine("Element not found in the array.");
                }
            }

            #endregion BinarySearch

            #region BubbleSort

            public static void BubbleSort()
            {
                /*
                 * Time Complexity: The bubble sort algorithm has a time complexity of O(n^2) - Quadratic in the worst and average case, 
                 * where n is the number of elements in the array. This is because the algorithm iterates over 
                 * the array multiple times, comparing and swapping adjacent elements.
                 * 
                 * Space Complexity: The space complexity of the bubble sort algorithm is O(1), which means it uses constant space. 
                 * The space required is independent of the size of the input array. Bubble sort only requires a few additional 
                 * variables for temporary storage during the swapping process
                 */
                int[] array = { 64, 34, 25, 12, 22, 11, 90 };
                int n = array.Length;
                //bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    //swapped = false;
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            // Swap array[j] and array[j+1]
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                            //swapped = true;
                        }
                    }

                    // If no elements were swapped in the inner loop, the array is already sorted
                    //if (!swapped)
                    //{
                    //    break;
                    //}
                }

                Console.WriteLine("Sorted array: " + string.Join(", ", array));
            }

            #endregion BubbleSort

            #region SelectionSort

            public static void SelectionSort()
            {
                /*
                 * Selection sort is a simple and efficient sorting algorithm that works by repeatedly selecting the smallest (or largest) 
                 * element from the unsorted portion of the list and moving it to the sorted portion of the list. 
                 * 
                 * Time Complexity: The selection sort algorithm has a time complexity of O(n^2) in the worst, best, and average cases, 
                 * where n is the number of elements in the array. This is because the algorithm requires two nested loops to find 
                 * the minimum element and perform the swap.
                 * 
                 * Space Complexity: The space complexity of the selection sort algorithm is O(1), indicating that it uses constant space. 
                 * The space required is independent of the size of the input array. Selection sort only requires a few additional variables 
                 * for temporary storage during the swapping process
                 */

                int[] array = { 64, 34, 25, 12, 22, 11, 90 };
                int n = array.Length;
                //bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;

                    // Find the index of the minimum element in the unsorted part of the array
                    for (int j = i + 1; j < n; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    // Swap the minimum element with the current element
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }

                Console.WriteLine("Sorted array: " + string.Join(", ", array));
            }

            #endregion SelectionSort

            static void Main(string[] args)
            {
                BinarySearch();
                BubbleSort();
                SelectionSort();
                Console.ReadKey();
            }
        }
    }
}
