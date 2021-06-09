using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADONET
{
    /*
     * ADO.Net is commonly termed as ActiveX Data Objects which is a part of .Net Framework. ADO.Net framework 
     * has set of classes which are used to handle data access by connecting with different databases like SQL,
     * Access, Oracle, etc
     * 
     * ExecuteNonQuery method is used to execute SQL Command or the storeprocedure performs, INSERT, UPDATE 
     * or Delete operations. It doesn't return any data from the database. Instead, it returns an integer 
     * specifying the number of rows inserted, updated or deleted.
     * 
     * ExecuteReader method is used to execute a SQL Command or storedprocedure returns a set of rows from the database.
     * 
     * ExecuteScalar method is used to execute SQL Commands or storeprocedure, after executing return a single value 
     * from the database. It also returns the first column of the first row in the result set from a database. - 
     * Manily used to return Identity.
     * 
     * ExecuteXMLReader This method executes the command specified and returns an instance of XmlReader class. 
     * This method can be used to return the result set in the form of an XML document.
     * 
     *  DataReader object provides a read only, forward only, high performance mechanism to retrieve
     *  data from a data store as a data stream, while staying connected with the data source. Using the 
     *  DataReader can increase application performance and reduce system overhead because only one row 
     *  at a time is ever in memory. After creating an instance of the Command object, you create a 
     *  DataReader by calling Command.ExecuteReader to retrieve rows from a data source.
     *  
     *  DataSet contains DataTableCollection and their DataRelationCollection . It represents a complete set 
     *  of data including the tables that contain, order, and constrain the data, as well as the relationships 
     *  between the tables. We can use Dataset in combination with DataAdapter Class . Build and fill each 
     *  DataTable in a DataSet with data from a data source using a DataAdapter. The DataSet object offers a 
     *  disconnected data source architecture.
     *  
     * Data Adapter is a part of ADO.NET data provider which acts as a communicator between Dataset and the Data source.
     * This Data adapter can perform Select, Insert, Update and Delete operations in the requested data source.
     
     */
    class Program
    {
        static void Main(string[] args)
        {
            TestDataReader dataReader = new TestDataReader();
            dataReader.TestSqlDataReader();
        }

        static DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerId", typeof(Int32));
            dt.Columns.Add("CustomerName", typeof(string));
            return dt;
        }

        class TestTableInsert
        {
            public void TableInsert()
            {
                //Create Table
                DataTable myTable = CreateTable();

                // Add New Rowto table
                myTable.Rows.Add(1, "Jignesh Trivedi");
                myTable.Rows.Add(2, "Tejas Trivedi");
                myTable.Rows.Add(3, "Rakesh Trivedi");

                SqlConnection connection = new SqlConnection("Data Source= DatabaseName;Initial Catalog=AdventureWorks;UserId = sa; Password = password; ");
                connection.Open();
                SqlCommand cmd = new SqlCommand("InsertValue", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //Pass table Valued parameter to Store Procedure
                SqlParameter sqlParam = cmd.Parameters.AddWithValue("@TempTable", myTable);
                sqlParam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();
                connection.Close();
                Console.Write("Data Save Successfully.");
            }
        }

        class TestDataReader
        {
            /* Properties:
             *Depth	            Indicates the depth of nesting for row
             *FieldCount	    Returns number of columns in a row
             *IsClosed	        Indicates whether a data reader is closed
             *Item	            Gets the value of a column in native format
             *RecordsAffected	Number of row affected after a transaction
             */

            /* Methods 
             * Close	    Closes a DataRaeder object.
             * Read	        Reads next record in the data reader.
             * NextResult	Advances the data reader to the next result during batch transactions.
             * Getxxx	    There are dozens of Getxxx methods. These methods read a specific data type 
             *                  value from a column. For example. GetChar will return a column value as a character and GetString as a string.
             */
            public void TestSqlDataReader()
            {
                // Create a connection string  
                string ConnectionString = "Integrated Security = SSPI; " +
                "Initial Catalog= Northwind; " + " Data source = localhost; ";
                string SQL = "SELECT * FROM Customers";

                // create a connection object  
                SqlConnection conn = new SqlConnection(ConnectionString);

                // Create a command object  
                SqlCommand cmd = new SqlCommand(SQL, conn);
                conn.Open();

                // Call ExecuteReader to return a DataReader  
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("customer ID, Contact Name, " + "Contact Title, Address ");
                Console.WriteLine("=============================");

                while (reader.Read())
                {
                    Console.Write(reader["CustomerID"].ToString() + ", "); // Or reader.GetString(0);
                    Console.Write(reader["ContactName"].ToString() + ", ");
                    Console.Write(reader["ContactTitle"].ToString() + ", ");
                    Console.WriteLine(reader["Address"].ToString() + ", ");
                }

                //reader.NextResult(); when we have multiple select quries and that is used to move to next result set.

                //Release resources  
                reader.Close();
                conn.Close();
            }
        }

        class TestDataSet
        {
            public void TestSqlDataSet()
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                int i = 0;
                string sql = null;

                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                sql = "Your SQL Statement Here";

                connection = new SqlConnection(connetionString);

                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    adapter.Dispose();
                    command.Dispose();
                    connection.Close();

                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        Console.WriteLine(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
        }
    }
}
