using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace IEnumIQuerIEnumrator
{
    /*
     * IEnumerable and IEnumerator both are interfaces in C#.
     * IEnumerable is an interface defining a single method GetEnumerator() that returns an IEnumerator interface.
     * This works for readonly access to a collection that implements that IEnumerable can be used with a foreach statement.
     * IEnumerator has two methods MoveNext and Reset. It also has a property called Current.

     * IEnumerable exists in the System.Collections namespace.
     * IQueryable exists in the System.Linq Namespace.
     * 
     * IEnumerable is suitable for querying data from in-memory collections like List, Array and so on.
     * IQueryable is suitable for querying data from out-memory (like remote database, service) collections
     * 
     * While querying data from the database, IEnumerable executes "select query" on the server-side, 
     *      loads data in-memory on the client-side and then filters the data.
     * While querying data from a database, IQueryable executes a "select query" on server-side with all filters.
     * 
     * IEnumerable is beneficial for LINQ to Object and LINQ to XML queries.
     * IQueryable is beneficial for LINQ to SQL queries.
     * 
     * IEnumerable: System.Collections
     * An IEnumerable is a list or a container which can hold some items. You can iterate through each element 
     * in the IEnumerable. You can not edit the items like adding, deleting, updating, etc. instead you just 
     * use a container to contain a list of items. It is the most basic type of list container. An IEnumerable
     * supports filtering elements using where clause.
     * 
     * ICollection: System.Collections
     * ICollection is another type of collection, which derives from IEnumerable and extends it’s functionality
     * to add, remove, update element in the list. ICollection also holds the count of elements in it and we 
     * does not need to iterate over all elements to get total number of elements.
     * 
     * IList: System.Collections
     * IList extends ICollection. An IList can perform all operations combined from IEnumerable and ICollection,
     * and some more operations like inserting or removing an element in the middle of a list. You can use a
     * foreach loop or a for loop to iterate over the elements. The IList interface implemented from two interfaces 
     * and they are ICollection and IEnumerable.
     * 
     * IList<string> ilist = new IList<string>();
         //This will throw error as we cannot create instance for an IList as it is an interface.
     */
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["testDatabase"].ToString();
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();
            List<string> Month = new List<string>();
            Month.Add("January");
            Month.Add("February");
            Month.Add("March");
            Month.Add("April");
            Month.Add("May");
            Month.Add("June");
            Month.Add("July");
            Month.Add("August");
            Month.Add("September");
            Month.Add("October");
            Month.Add("November");
            Month.Add("December");

            IEnumerable<string> iEnumerableOfString = (IEnumerable<string>)Month;
            foreach (string AllMonths in iEnumerableOfString)
            {
                Console.WriteLine(AllMonths);
            }

            IEnumerator<string> iEnumeratorOfString = Month.GetEnumerator();//to convert list into IEnumerator we can invoke the GetEnumerator method  
            while (iEnumeratorOfString.MoveNext())
            {
                Console.WriteLine(iEnumeratorOfString.Current);
                if (iEnumeratorOfString.Current == "June")
                {
                    iEnumeratorMethodTwo(iEnumeratorOfString);
                }
            }

        }

        static void iEnumeratorMethodTwo(IEnumerator<string> i)
        {
            while (i.MoveNext())
            {
                Console.WriteLine(i.Current);
            }
        }
    }
}
