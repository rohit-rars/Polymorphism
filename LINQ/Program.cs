using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQ
{
    /*
     * LINQ (Language Integrated Query) is uniform query syntax in C# and VB.NET to retrieve data from different sources and formats. 
     * It is integrated in C# or VB, thereby eliminating the mismatch between programming languages and databases, as well as providing 
     * a single querying interface for different types of data sources.
     * 
     * LINQ is a structured query syntax built in C# and VB.NET to retrieve data from different types of data sources such as collections, 
     * ADO.Net DataSet, XML Docs, web service and MS SQL Server and other databases.
     * 
     * LINQ to Objects, LINQ to DataSet, LINQ to XML, LINQ to Entities, LINQ to SQL
     */
    class Program
    {
        public class Employee
        {
            public int ID;
            public int Salary;
            public int DEPT_ID;
            public string Name;
        }

        public class Department
        {
            public int DEPT_ID;
            public string DEPT_Name;
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                 new Employee {ID=101,   Name="Amit  "    , Salary=4000,DEPT_ID=101},
                 new Employee {ID=102,   Name="Amit  "    , Salary=3800,DEPT_ID=102},
                 new Employee {ID=103,   Name="Salman"    , Salary=7000,DEPT_ID=103},
                 new Employee {ID=104,   Name="Ram   "    , Salary=5000,DEPT_ID=101},
                 new Employee {ID=105,   Name="Shyam "    , Salary=7000,DEPT_ID=102},
                 new Employee {ID=106,   Name="Kishor"    , Salary=6000,DEPT_ID=103},
            };

            List<Department> departments = new List<Department>()
            {
                 new Department {DEPT_ID=101,   DEPT_Name="HR        "   },
                 new Department {DEPT_ID=102,   DEPT_Name="ACCOUNTS  "   },
                 new Department {DEPT_ID=103,   DEPT_Name="SALES     "   },
            };

            var ResultQuery = (from emp in employees
                               join dept in departments
                               on emp.DEPT_ID equals dept.DEPT_ID
                               select new
                               {
                                   ID = emp.ID,
                                   Name = emp.Name,
                                   Salary = emp.Salary,
                                   DeptName = dept.DEPT_Name
                               }).ToList();

            Console.WriteLine("Employee Details: ");
            foreach (var e in ResultQuery)
            {
                Console.WriteLine("\tID: " + e.ID + ", Name: " + e.Name + ", Salary: " + e.Salary + ", Department: " + e.DeptName);
            }

            var result = employees.GroupBy(x => x.Salary).OrderByDescending(y => y.Key).Skip(1).FirstOrDefault();
            
            Console.WriteLine(string.Format("2nd Highest Salary is: {0}", result.Key));


            Console.ReadLine();
        }
    }
}
