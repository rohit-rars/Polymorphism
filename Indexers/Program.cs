using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    /*
     * An indexer allows an instance of a class or struct to be indexed as an array. 
     * If the user will define an indexer for a class, then the class will behave like 
     * a virtual array. 
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // creating an object of parent class which
            // acts as primary address for using Indexer
            IndexerCreation ic = new IndexerCreation();

            // Inserting values in ic[]
            // Here we are using the object
            // of class as an array
            ic[0] = "C";
            ic[1] = "CPP";
            ic[2] = "CSHARP";

            Console.Write("Printing values stored in objects used as arrays\n");

            // printing values 
            Console.WriteLine("First value = {0}", ic[0]);
            Console.WriteLine("Second value = {0}", ic[1]);
            Console.WriteLine("Third value = {0}", ic[2]);

            //Generic Indexers
            GenericIndexer<int> genericIndexer = new GenericIndexer<int>(5);
            genericIndexer[0] = 1;
            genericIndexer[1] = 2;
            genericIndexer[2] = 3;
            genericIndexer[3] = 4;
            genericIndexer[4] = 5;

            for (int i = 0; i < genericIndexer.Length; i++)
            {
                Console.WriteLine(genericIndexer[i]);
            }

            Console.ReadKey();
        }
    }

    class IndexerCreation
    {
        // class members
        private string[] val = new string[3];

        // Indexer declaration
        // public - access modifier
        // string - the return type of the Indexer
        // this - is the keyword having a parameters list
        public string this[int index]
        {

            get
            {
                if (index < 0 || index >= val.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return val[index];
            }

            set
            {
                if (index < 0 || index >= val.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                val[index] = value;
            }
        }
    }

    class GenericIndexer<T>
    {
        private T[] genericObject;
        public GenericIndexer()
        {
            genericObject = new T[3];
        }

        public GenericIndexer(int length)
        {
            genericObject = new T[length];
        }

        public T this[int index]
        {

            get
            {
                if (index < 0 || index >= genericObject.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return genericObject[index];
            }

            set
            {
                if (index < 0 || index >= genericObject.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                genericObject[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return genericObject.Length;
            }
        }
    }
}
