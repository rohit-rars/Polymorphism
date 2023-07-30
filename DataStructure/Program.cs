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
            generalOpr.StatckOps();
            Console.ReadKey();
        }

        class GeneralOperations
        {
            // Count Paranthesis
            public void CheckOpenAndClosedParanthesis(string checkString, char parentheSistoCheckOpen, char parentheSistoCheckClose)
            {
                int count = 0;
                string message = "All Ok";
                foreach (char c in checkString)
                {
                    if (c.Equals(parentheSistoCheckOpen))
                    {
                        count++;
                    }
                    else if(c.Equals(parentheSistoCheckClose))
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

            //public void QueueOps()
            //{
            //    bool isError = false;
            //    string tempString = @"Hi this is Rohit {([[]])}(check sum)";
            //    Queue<char> charQueue = new Queue<char>();
            //    foreach (var currentItem in tempString)
            //    {
            //        //char currentItem = tempString[i];
            //        switch (currentItem)
            //        {
            //            case '{':
            //            case '(':
            //            case '[':
            //                charQueue.Enqueue(currentItem);
            //                break;
            //            case ']':
            //                var tempChar = charQueue.Dequeue();
            //                if(tempChar != '[')
            //                    isError = true;

            //                break;
            //            case '}':
            //                var tempCurly = charQueue.Dequeue();
            //                if (tempCurly != '{')
            //                    isError = true;

            //                break;
            //            case ')':
            //                var tempRound = charQueue.Dequeue();
            //                if (tempRound != '(')
            //                    isError = true;

            //                break;
            //            default:
            //                break;
            //        }

            //        if (isError)
            //            break;

            //    }

            //    if (isError || charQueue.Count > 0)
            //    {
            //        Console.WriteLine("Everything not Looking Good");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Everything Looks Good");
            //    }
            //}

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

                int arrayLength = tempArray.Length -1;
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
