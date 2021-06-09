using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Oracle
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }


        class OracleTest
        {
            public void OralceTestMethod()
            {
                string connectionString = "";
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            command.CommandText = "";
                            OracleDataAdapter dataAdapter = new OracleDataAdapter(command);
                            DataSet data = new DataSet();
                            dataAdapter.Fill(data);
                            if (data != null && data.Tables.Count > 0)
                            {
                                DataTable dataTable = data.Tables[0];
                                foreach (DataRow row in data.Tables[0].Rows)
                                {

                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
    }
}
