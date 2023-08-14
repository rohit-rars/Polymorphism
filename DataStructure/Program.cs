using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Stack
            //var stackObj = new StackOperations();
            //stackObj.PushOperation(10);
            //stackObj.PushOperation(30);
            //stackObj.PopOperation();
            //stackObj.PushOperation(20);
            //stackObj.PrintStack();

            ////Queue
            //var queueObj = new QueueOperation();
            //queueObj.Enqueue(10);
            //queueObj.Enqueue(30);
            //queueObj.PrintQueue();
            //queueObj.Dequeue();
            //queueObj.Enqueue(20);
            //queueObj.PrintQueue();

            //var arrayOpr = new ArrayOperations();
            //int[] array1 = new int[] { 3, 5, 12, 9, 15, 14, 18, 20, 25, 28 };
            //int[] array2 = new int[] { 36, 38, 30, 32, 34 };
            //arrayOpr.MergeAndSort(array2, array1);

            var generalOpr = new GeneralOperations();
            //string testString = @"Hello {this is Rohit.{{I am from Chandigah}}";
            //generalOpr.CheckOpenAndClosedParanthesis(testString, '{', '}');
            //generalOpr.JoinListAsString();
            //generalOpr.StatckOps();
            generalOpr.CheckOpenAndClosedParanthesisAll();
            generalOpr.MoveZerosAtEnd();
            Console.ReadKey();
        }

        class AllCollections
        {
           
            public void CheckCollections()
            {
                List<string> listString = new List<string>()
                {
                    "Rohit",
                    "Rahul",
                    "Rajwinder",
                    "Raghu",
                    "Nitish"
                };

                var result = listString.Where(x => x.StartsWith("R"));
                var enumRator = result.GetEnumerator();
                while(enumRator.MoveNext())
                {
                    Console.WriteLine(enumRator.Current);
                }
            }

        }

        class GeneralOperations
        {
            //Move All Zeros at the end of Array
            public void MoveZerosAtEnd()
            {
                int[] mainArray = { 1, 2, 0, 3, 4, 0, 0, 6 };
                int count = 0;
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (mainArray[i] != 0)
                    {
                        mainArray[count] = mainArray[i];
                        count++;
                    }
                }

                while (count < mainArray.Length)
                {
                    mainArray[count] = 0;
                    count++;
                }
            }

            // Join List As String 
            public void JoinListAsString()
            {
                var listObj = new List<string>()
                {
                    "Rohit",
                    "Test1",
                    "AbcTest"
                };

                Console.WriteLine(string.Join(", ", listObj));
            }

            // Count Paranthesis
            public void CheckOpenAndClosedParanthesis(string checkString)
            {
                int count = 0;
                string message = "All Ok";
                foreach (char c in checkString)
                {
                    if (c.Equals('{'))
                    {
                        count++;
                    }
                    else if(c.Equals('}'))
                    {
                        if (count > 0)
                        {
                            count--;
                        }
                        else
                        {
                            message = "Missing Open Paranthesis";
                        }
                    }
                }

                if(count > 0)
                    message = "Missing Close Paranthesis";

                Console.WriteLine(message);
            }

            public void CheckOpenAndClosedParanthesisAll()
            {
                int count = -1;
                string message = @"{([[]])}()";
                bool isError = false;
                char[] charStack = new char[message.Length];
                foreach (char c in message)
                {
                    switch (c)
                    {
                        case '{':
                            count++;
                            charStack[count] = '}';
                            break;
                        case '(':
                            count++;
                            charStack[count] = ')';
                            break;
                        case '[':
                            count++;
                            charStack[count] = ']';
                            break;
                        case ']':
                        case '}':
                        case ')':
                            if (count < 0)
                                isError = true;

                            if (!isError)
                            {
                                if (charStack[count] != c)
                                    isError = true;

                                charStack[count] = default;
                                count--;
                            }
                            break;
                        default:
                            break;
                    }
                }


                if (isError || count > -1)
                {
                    Console.WriteLine("Everything not Looking Good");
                }
                else
                {
                    Console.WriteLine("Everything Looks Good");
                }
            }

            public void StatckOps()
            {
                bool isError = false;
                string tempString = @"Hi this is Rohit {([[]])}(check sum)";
                Stack<char> charStack = new Stack<char>();
                foreach (char currentItem in tempString)
                {
                    switch (currentItem)
                    {
                        case '{':
                            charStack.Push('}');
                            break;
                        case '(':
                            charStack.Push(')');
                            break;
                        case '[':
                            charStack.Push(']');
                            break;
                        case ']':
                        case '}':
                        case ')':
                            if (charStack.Count == 0)
                                isError = true;
                            else if (charStack.Pop() != currentItem)
                                isError = true;

                            break;
                        default:
                            break;
                    }

                    if (isError)
                        break;

                }

                if(isError || charStack.Count > 0)
                {
                    Console.WriteLine("Everything not Looking Good");
                }
                else
                {
                    Console.WriteLine("Everything Looks Good");
                }
            }
        }

        class ArrayOperations
        {
            public static void ShiftArrayElementSameArray()
            {
                int[] tempArray = new int[] { 1, 2, 3, 4, 5 };
                int n = tempArray.Length;
                int numberOfelementsToShift = 2;
                for (int i = 0; i < numberOfelementsToShift; i++)
                {
                    int elementToShift = tempArray[0];
                    for (int j = 0; j < n - 1; j++)
                    {
                        tempArray[j] = tempArray[j + 1];
                    }

                    tempArray[n - 1] = elementToShift;
                }


                Console.WriteLine(string.Join(", ", tempArray));
            }

            public static void ShiftArrayElement()
            {
                int[] tempArray = new int[] { 1, 2, 3, 4, 5 };
                int[] newArray = new int[tempArray.Length];
                int j = 0, elementsToShift = 2;
                for (int i = elementsToShift; i < tempArray.Length; i++)
                {
                    newArray[j] = tempArray[i];
                    j++;
                }

                for (int i = 0; i < elementsToShift; i++)
                {
                    newArray[j] = tempArray[i];
                    j++;
                }

                Console.WriteLine(string.Join(", ", newArray));
            }

            public void MergeAndSort(int[] firstArray, int[] secondArry)
            {
                int newArraySize = firstArray.Length + secondArry.Length;
                int[] finalArray = new int[newArraySize];

                firstArray = SortArray(firstArray);
                secondArry = SortArray(secondArry);

                int i = 0, j = 0, k = 0;
                while (i < firstArray.Length && j < secondArry.Length)
                {
                    if (firstArray[i] < secondArry[j])
                    {
                        finalArray[k] = firstArray[i];
                        i++;
                    }
                    else
                    {
                        finalArray[k] = secondArry[j];
                        j++;
                    }

                    k++;
                }

                while(i < firstArray.Length)
                {
                    finalArray[k] = firstArray[i];
                    i++;
                    k++;
                }

                while (j < secondArry.Length)
                {
                    finalArray[k] = secondArry[j];
                    j++;
                    k++;
                }

                foreach (int item in finalArray)
                {
                    Console.WriteLine(item);
                }
            }

            public void MergeAndSortArray(int[] firstArray, int[] secondArry)
            {
                var mergedArray = firstArray.Concat(secondArry).ToArray();
                var result = SortArray(mergedArray);

                Console.WriteLine("Merge and Sorted Array is:");
                foreach (int item in result)
                {
                    Console.WriteLine(item);
                }
            }

            public int[] SortArray(int[] tempArray)
            {
                //Bubble Sort
                /*
                 * Time Complexity: The bubble sort algorithm has a time complexity of O(n^2) - Quadratic in the worst and average case, 
                 * where n is the number of elements in the array. This is because the algorithm iterates over 
                 * the array multiple times, comparing and swapping adjacent elements.
                 * 
                 * Space Complexity: The space complexity of the bubble sort algorithm is O(1), which means it uses constant space. 
                 * The space required is independent of the size of the input array. Bubble sort only requires a few additional 
                 * variables for temporary storage during the swapping process
                 */

                int arrayLength = tempArray.Length - 1;
                for (int i = 0; i < arrayLength; i++)
                {
                    for (int j = 0; j < arrayLength - i; j++)
                    {
                        if (tempArray[j] > tempArray[j + 1])
                        {
                            int tempValue = tempArray[j];
                            tempArray[j] = tempArray[j + 1];
                            tempArray[j + 1] = tempValue;
                        }
                    }
                }

                return tempArray;
            }

            public void SelectionSort()
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
                List<int> list = new List<int>();
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

            public void BinarySearch()
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
                    int mid = (left + right) / 2;

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
        }

        class QueueOperation
        {
            static readonly int MAXQUEUESIZE = 100;
            int lastElement;
            int[] queueArray = new int[MAXQUEUESIZE];

            public QueueOperation()
            {
                lastElement = -1;
            }

            public void Enqueue(int value)
            {
                if (lastElement == MAXQUEUESIZE)
                {
                    Console.WriteLine("Queue Overflow.");
                }
                else
                {
                    lastElement++;
                    queueArray[lastElement] = value;
                }
            }

            public void Dequeue()
            {
                if (lastElement < 0)
                {
                    Console.WriteLine("Queue Underflow.");
                }
                else
                {
                    Console.WriteLine("Dequeued Element: {0}", queueArray[lastElement]);
                    lastElement--;
                }
            }

            public void PrintQueue()
            {
                if (lastElement < 0)
                {
                    Console.WriteLine("Queue Underflow.");
                }
                else
                {
                    Console.WriteLine("Queue Elements: ");
                    for (int i = 0; i <= lastElement; i++)
                    {
                        Console.WriteLine(queueArray[i]);
                    }
                }
            }
        }

        class StackOperations
        {
            static readonly int MAX = 100;
            int top;
            int[] stackArray = new int[MAX];

            public StackOperations()
            {
                top = -1;
            }

            public bool IsEmpty()
            {
                return top < 0;
            }

            public bool IsFull()
            {
                return top >= MAX;
            }

            public bool PushOperation(int value)
            {
                bool finalResult;
                if (IsFull())
                {
                    finalResult = false;
                    Console.WriteLine("Stack Overflow");
                }
                else
                {
                    stackArray[++top] = value;
                    finalResult = true;
                }

                return finalResult;
            }

            public void Peek()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack Underflow");
                }
                else
                {
                    Console.WriteLine("Stack Top Element is: {0}", stackArray[top]);
                }
            }

            public int PopOperation()
            {
                int popValue;
                if (IsEmpty())
                {
                    popValue = -1;
                    Console.WriteLine("Stack Underflow");
                }
                else
                {
                    popValue = stackArray[top--];
                }

                return popValue;
            }

            public void PrintStack()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Stack Underflow");
                }
                else
                {
                    Console.WriteLine("Stack Elements: ");
                    for (int i = top; i >= 0; i--)
                    {
                        Console.WriteLine(stackArray[i]);
                    }
                }
            }
        }
    }
}
